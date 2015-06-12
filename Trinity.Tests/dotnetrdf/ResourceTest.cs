﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Core;
using Semiodesk.Trinity;
using NUnit.Framework;

namespace dotNetRDFStore.Test
{
    class ResourceTest
    {
        IStore Store;
        IModel Model;

        [SetUp]
        public void SetUp()
        {
            Store = Stores.CreateStore("provider=dotnetrdf");


            Uri testModel = new Uri("ex:Test");
            Model = Store.CreateModel(testModel);
        }

        [TearDown]
        public void TearDown()
        {
            Store.Dispose();
            Store = null;
        }

        #region Datatype fidelity Test

        [Test]
        public void TestBool()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);

            bool val = true;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(bool), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestInt()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);

            int val = 123;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(int), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestInt16()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            Int16 val = 124;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(Int16), res.GetType());
            Assert.AreEqual(val, res);

        }

        [Test]
        public void TestInt32()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            Int32 val = 125;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(Int32), res.GetType());
            Assert.AreEqual(val, res);

        }

        [Test]
        public void TestInt64()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            Int64 val = 126;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(Int64), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestUint()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            uint val = 126;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(uint), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestUint16()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            UInt16 val = 126;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(UInt16), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestUint32()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            UInt32 val = 126;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(UInt32), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestUint64()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            UInt64 val = 126;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(UInt64), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestFloat()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            float val = 1.234F;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(float), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestDouble()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            double val = 1.223;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(double), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestSingle()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            Single val = 1.223F;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(Single), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestString()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            string val = "Hello World!";
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(string), res.GetType());
            Assert.AreEqual(val, res);
        }

        [Test]
        public void TestDateTime()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);
            DateTime val = DateTime.Today;
            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(DateTime), res.GetType());
            Assert.AreEqual(val.ToLocalTime(), ((DateTime)res).ToLocalTime());
        }

        [Test]
        public void TestByteArray()
        {
            Uri resourceUri = new Uri("ex:myResource");
            Property myProperty = new Property(new Uri("ex:myProperty"));
            Resource r1 = Model.CreateResource<Resource>(resourceUri);

            byte[] val = new byte[] { 1, 2, 3, 4, 5 };

            r1.AddProperty(myProperty, val);
            r1.Commit();
            r1 = Model.GetResource<Resource>(resourceUri);

            object res = r1.ListValues(myProperty).First();

            Assert.AreEqual(typeof(byte[]), res.GetType());
            Assert.AreEqual(val, res);

        }


        #endregion

    }
}