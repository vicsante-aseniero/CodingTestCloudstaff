using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Diana.Code.Challenge
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
  /// 1. PHP_Salary_1 data property should be in Decimal since it involves Money
  /// 2. The US_Salary_2 get property should use divide not multiply in order to get the correct US salary 
  /// 3. The exchange rate 51.6932 should not be static since exchange rates constantly change this should current exchange US rate to Philippine Peso
  /// </answer>
  public Double PHP_Salary_1 { get; set; }

  public decimal US_Salary_2
  {
   get
   {
    return ((decimal)PHP_Salary_1) * ((decimal)51.6932);
   }
  }

  public string Email { get; set; }

  public int CompareTo(object obj)
  {
   return this.Id.CompareTo(((employee)obj).Id);
  }
 }
}
