using System;
using System.Collections.Generic;

namespace Diana.Code.Chaallenge
{
    /// <question>
    /// Please refactor this class and related interfaces as required to meet your
    /// minimum coding standards.
    /// </question>
    public class employee : iCachedObject
    {
        /// <question>
        /// What is the purpose of this attribute?
        /// </question>
        /// <answer>
        ///
        /// </answer>
        [BsonId]
        public Guid Id { get; set; }

        public string name { get; set; }

        public string _description { get; set; }

        /// <question>
        /// Review the next two properties, what suggestions do you have
        /// for these?
        /// </question>
        /// <answer>
        ///
        /// </answer>
        public Double PHP_Salary_1 { get; set; }

        public decimal US_Salary_2
        {
        get
        {
        return ((decimal) PHP_Salary_1) * ((decimal)51.6932);
        }
        }

            public string Email { get; set; }

        public int CompareTo(object obj)
        {
            return this.Id.CompareTo(((employee)obj).Id);
        }
    }
}
