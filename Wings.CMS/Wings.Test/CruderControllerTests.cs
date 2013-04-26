﻿using FakeItEasy;
using NUnit.Framework;
using Wings.Core;
using Wings.Core.Model;
using Wings.Core.Service;
using Wings.UI.Mappers;
using Wings.UI.Controllers;
using Wings.UI.Dto;

namespace Wings.Tests
{
    public class CruderControllerTests
    {
        CountryController c;

        [Fake]
        IMapper<Country, CountryInput> v;
        [Fake]
        ICrudService<Country> s;

        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
            c = new CountryController(s, v);
        }

        [Test]
        public void CreateShouldBuildNewInput()
        {
            c.Create();
            A.CallTo(() => v.MapToInput(A<Country>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void CreateShouldReturnViewForInvalidModelstate()
        {
            c.ModelState.AddModelError("", "");
            c.Create(A.Fake<CountryInput>()).ShouldBeViewResult();
        }

        [Test]
        public void EditShouldReturnCreateView()
        {
            A.CallTo(() => s.Get(1)).Returns(A.Fake<Country>());
            c.Edit(1).ShouldBeViewResult().ShouldBeCreate();
            A.CallTo(() => s.Get(1)).MustHaveHappened();
        }

        [Test]
        public void EditShouldThrowException()
        {
            A.CallTo(() => s.Get(1)).Returns(null);
            Assert.Throws<WingsException>(() => c.Edit(1));
            A.CallTo(() => v.MapToInput(A<Country>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        public void EditShouldReturnViewForInvalidModelstate()
        {
            c.ModelState.AddModelError("", "");
            c.Edit(A.Fake<CountryInput>()).ShouldBeViewResult().ShouldBeCreate();
        }

        [Test]
        public void EditShouldReturnContentOnError()
        {
            A.CallTo(() => v.MapToEntity(A<CountryInput>.Ignored, A<Country>.Ignored)).Throws(new WingsException("aa"));
            c.Edit(A.Fake<CountryInput>()).ShouldBeContent().Content.ShouldEqual("aa");
        }

        [Test]
        public void DeleteShouldRedirectToIndex()
        {
            c.Delete(1).ShouldBeJson();
            A.CallTo(() => s.Delete(1)).MustHaveHappened();
        }
    }
}
