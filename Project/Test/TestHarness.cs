using System;
using System.Diagnostics;

namespace Diana.Code.Challenge
{
    /// <summary>
    /// The test harness creates each cache implementation (fast/slow) and executes the
    /// methods. Your challenge is to implement the fast cache and make it super fast.
    /// </summary>
    public class TestHarness
    {
        private int _count;

        /// <question>
        /// What is a uint and why would you use one?
        /// </question>
        /// <answer>
        ///
        /// </answer>

        private uint _testNumber;

        private uint _loopNumber;

        private iCacheStuff<employee> _cache;

        private String _results;

        public TestHarness()
        {
        }

        private iCachedObject a;
        private iCachedObject b;
        private iCachedObject c;

        protected TestHarness Setup(iCacheStuff<employee> cache, int count, uint testNumber, uint loopNumber, Func<Guid, string, string, employee> createItem)
        {
            _cache = cache;
            _count = count;
            _testNumber = testNumber;
            _loopNumber = loopNumber;

            Console.WriteLine($"\r\n\r\n{_cache.CacheName}\r\n");

            for (int i = 0; i < _count; i++)
            {
                var item = createItem(
                    Guid.NewGuid(),
                    $"Name {i}",
                    "Description " + i.ToString("0000")
                );

                if (i == 0) a = item;
                if (i == _count/2) b = item;
                if (i == _count - 1) c = item;

                _cache.AddItem(item);
            }

            return this;
        }

        public iCachedObject First()
        {
            return a;
        }

        public iCachedObject Last()
        {
            return c;
        }

        public iCachedObject Mid()
        {
            return b;
        }
        /// <question>
        /// What is the recommended usage of vars?
        /// </question>
        /// <answer>
        ///
        /// </answer>
        public TestHarness Run()
        {
            var firstItem = First();
            var lastItem = Last();
            iCachedObject midItem = Mid();

            uint totalTests = _testNumber;

            TestFind("First Item ", firstItem, totalTests);
            TestFind("Mid Item   ", midItem, totalTests);
            TestFind("Last Item  ", lastItem, totalTests);

            return this;
        }

        /// <question>
        /// What improvements you suggest to the coder for this method?
        /// Please refactor/change this method and make it better.
        /// Describe what you did.
        /// </question>
        /// <answer>
        ///
        /// </answer>
        private bool TestFind(string testName, iCachedObject objectToFind, uint totalTests)
        {
            if (objectToFind == null)
            {
            Console.WriteLine("Not Implemented");
            return false;
            }

            long totalTicks = 0;
            long minTicks = long.MaxValue;
            long maxTicks = long.MinValue;

            bool match = true;
            var testWatch = new Stopwatch(); testWatch.Start();

            for (int run = 0; run < totalTests; run++)
            {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            int i = 0;
            iCachedObject result;

            do
            {
            result = _cache.FindItem(objectToFind.Id);
            match &= (result != null) && result.Id == objectToFind.Id;

            Console.Write($"\r{testName} {run+1}.{i}  ");
            }
            while (match && i++ < _loopNumber);

            stopWatch.Stop();

            totalTicks += stopWatch.ElapsedTicks;

            if (minTicks > stopWatch.ElapsedTicks) minTicks = stopWatch.ElapsedTicks;
            if (maxTicks < stopWatch.ElapsedTicks) maxTicks = stopWatch.ElapsedTicks;
            }

            testWatch.Stop();

            TimeSpan totalTime = TimeSpan.FromMilliseconds(testWatch.ElapsedMilliseconds);

            string stats = $"(found={match,-5}) | min:{minTicks,12} ticks | avg ms per find:{totalTime.TotalMilliseconds / (totalTests * 1.0 * _loopNumber),10:#####0.00} ms | max:{maxTicks,12} ticks | #Tests: {totalTests,3} | Total Time: {totalTime.TotalMilliseconds,7:0} ms |";

            _results += $"{testName,10} {stats}\r\n";

            Console.WriteLine(stats);
            return match;
        }

        public void Output()
        {
            Console.WriteLine(_results);
        }
    }
}
