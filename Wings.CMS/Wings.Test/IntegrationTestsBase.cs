﻿using NUnit.Framework;
using System.Transactions;

namespace Wings.Tests
{
    public class IntegrationTestsBase
    {
        private TransactionScope scope;

        [SetUp]
        public void Initialize()
        {
            scope = new TransactionScope();
        }

        [TearDown]
        public void TestCleanup()
        {
            scope.Dispose();
        }
    }
}