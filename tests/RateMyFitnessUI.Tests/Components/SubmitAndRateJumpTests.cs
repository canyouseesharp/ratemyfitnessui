using Bunit;
using FluentAssertions;
using NUnit.Framework;
using RateMyFitness.UI.Components;

namespace RateMyFitness.UI.Tests.Components
{
    public class SubmitAndRateJumpTests : Bunit.TestContext
    {
        [Test]
        public void HasCorrectFormElements()
        {
            // Arrange
            var cut = RenderComponent<JumpMeasurementForm>();
            var measurement = cut.Find("input[id='measurement']");
            var gender = cut.Find("select[id='gender']");
            var age = cut.Find("input[id='age']");
            var submit = cut.Find("button[type='submit']");

            // Act

            // Assert
            measurement.Should().NotBeNull();
            age.Should().NotBeNull();
            gender.Should().NotBeNull();
            submit.Should().NotBeNull();
        }

        [TestCase(1.0d, 3, "None")]
        [TestCase(0.0d, 1000, "Female")]
        [TestCase(101.0d, 40, "Non Existent")]
        public void RatingNotRenderedForInvalidData(decimal measurement, int age, string gender)
        {
            // Arrange
            var cut = RenderComponent<JumpMeasurementForm>();
            var measurementElement = cut.Find("input[id='measurement']");
            var ageElement = cut.Find("input[id='age']");
            var genderElement = cut.Find("select[id='gender']");
            var submit = cut.Find("button[type='submit']");
            var rating = cut.Find("#rating");

            // Act
            measurementElement.Change(measurement);
            ageElement.Change(age);
            genderElement.Change(gender);
            submit.Click();

            // Assert
            rating.TextContent.Should().BeEmpty();
        }

        [TestCase(24.0d, 30, "None")]
        [TestCase(20.0d, 44, "Female")]
        [TestCase(18.0d, 24, "Male")]
        public void RatingRenderedForValidData(decimal measurement, int age, string gender)
        {
            // Arrange
            var cut = RenderComponent<JumpMeasurementForm>();
            var measurementElement = cut.Find("input[id='measurement']");
            var ageElement = cut.Find("input[id='age']");
            var genderElement = cut.Find("select[id='gender']");
            var submit = cut.Find("button[type='submit']");
            var rating = cut.Find("#rating");

            // Act
            measurementElement.Change(measurement);
            ageElement.Change(age);
            genderElement.Change(gender);
            submit.Click();

            // Assert
            rating.TextContent.Should().NotBeEmpty();
        }
    }
}

