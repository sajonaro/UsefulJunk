using NUnit.Framework;
using Utilities.Extensions;

namespace Utilities.Tests
{
	/// <summary>
	/// Just a PoC class
	/// </summary>
	class Street
	{
		public string Name { get; set; }
		public int Number { get; set; }
	}

	/// <summary>
	/// Just a PoC class
	/// </summary>
	class Address
	{
		public Street Street { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
	}


	[TestFixture]
	public class MonadsTests {

		private Address _noStreetAddress;
		private Address _validAddress;
		
		[SetUp]
		public void FixtureSetUp()
		{
			//arrange
			_noStreetAddress = new Address { City = "chicago", ZipCode = "ABC" };

			_validAddress = new Address {
				City = "chicago", 
				ZipCode = "ABC",
				Street = new Street()
					{
						Name = "Elm street",
						Number = 13
					}
			};
			
		}


		[Test]
		public void MaybeMonadWithTest()
		{
			

			//act
			var streetName = _noStreetAddress.
								With( x => x.Street ).
								With(x => x.Name);

			var streetNumber = _noStreetAddress.
								With( x => x.Street ).
								With( x => x.Number);

			Assert.IsNullOrEmpty(streetName);
			Assert.IsTrue(streetNumber == 0 );

		}

		[Test]
		public void MaybeMonadWithTest1()
		{


			//act
			var streetName = _validAddress.
								With( x => x.Street ).
								With( x => x.Name );

			var streetNumber = _validAddress.
								With( x => x.Street ).
								With( x => x.Number );

			Assert.IsTrue( streetName == _validAddress.Street.Name );
			Assert.IsTrue( streetNumber == _validAddress.Street.Number);

		}



	}
}