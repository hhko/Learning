﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03_RepoPattern
{
    public interface IEntity
    {
        bool IsValid2();
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person, IEntity
    {
        public int Id { get; set; }

        public bool IsValid2()
        {
            return true;
        }

        public virtual void DoWork()
        {
            Console.WriteLine("DoWork - Employee");
        }
    }

    public class Manager : Employee
    {
        public override void DoWork()
        {
            Console.WriteLine("DoWork - Manager");
        }
    }
}
