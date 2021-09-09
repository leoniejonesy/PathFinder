using NUnit.Framework;
using PathFinder.Services;

namespace PathFinder.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void Validate_WithInvalidValues_ShouldReturnFalse()
        {
            string invalidValue1 = "";
            string invalidValue2 = null;

            var validator = new Validator();

            var result = validator.Valid(invalidValue1, invalidValue2);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Validate_WithValidValues_ShouldReturnTrue()
        {
            string value1 = "a valid value";
            string value2 = "another valid value";

            var validator = new Validator();

            var result = validator.Valid(value1, value2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Validate_WithValidAndInvalidValues_ShouldReturnFalse()
        {
            string validValue = "a valid value";
            string invalidValue = null;

            var validator = new Validator();

            var result = validator.Valid(validValue, invalidValue);

            Assert.That(result, Is.False);
        }
    }
}
