using NUnit.Framework;
using System.Collections.Generic;
using TakeNoteBlazor.Server.Models;

namespace TakeNoteUnitTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestQuizMasterisMaster()
		{
			//Arrange
			var id = 1;
			var author = "admin@admin.com";
			var quizMaster = new QuizMaster() { QuestionIds = new List<int>() { id }, 
												Author = author };

			//Act
			var result = quizMaster.IsMaster(id, author);

			//Assert
			Assert.IsTrue(result);
		}

		[Test]
		public void TestApiNoteResponse()
		{
			//Arrange

			//Act

			//Assert

		}
	}
}