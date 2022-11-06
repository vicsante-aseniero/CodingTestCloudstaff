using System;
using System.Collections.Generic;
using Diana.Code.Challenge;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Diana.Code.Challenge
{
 /// <summary>
 /// Company class that contains information about the company and its employees.
 /// </summary>
 public class Company : iCachedObject
 {
  [BsonId]
  public Guid Id { get; set; }

  public string name { get; set; }

  public string Description { get; set; }

  public Decimal Profit_1 { get; set; }

  public Double Profit_2 { get; set; }

  /// <question>
  /// What issues can you see with using string as the key for the dictionary?
  /// What suggestions do you have to resolve this?
  /// </question>
  /// <answer>
  /// It would be a better approach to use "Guid" instead of "string" as a key since it will be unique i.e Guid.NewGuid()
  /// </answer>
  public Dictionary<string, employee> Employees { get; set; } = new Dictionary<string, employee>();

  public int CompareTo(object obj)
  {
   return this.Id.CompareTo(((employee)obj).Id);
  }
 }
}
