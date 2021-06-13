using EJournalBLL.Models;
using EJournalBLL.Services;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Tests
{
    class ExerciseServiceTests
    {
        private Mock<IExercisesRepository> _mock;
        private ExercisesService _exercisesRepository;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IExercisesRepository>();
            _exercisesRepository = new ExercisesService(_mock.Object);
        }

        [TestCaseSource(typeof(GetAllExercise))]
        public void GetAllExercises_WhenExerciseService_ShouldReturnAllExercises(Group group, List<ExerciseDTO> RepositoryReturns, List<Exercise> expectedExercise)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetExercisesByGroup(group.Id))).Returns(RepositoryReturns);

            List<Exercise> actualExercise = _exercisesRepository.GetExercisesByGroup(group);

            CollectionAssert.AreEqual(expectedExercise, actualExercise);
        }

        private class GetAllExercise : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int startIdExercise = 1;
                int countExercise = 5;
                Group group = BLLMock.GetGroupMock(1);
                List<ExerciseDTO> exerciseDTO = new List<ExerciseDTO>();

                for (int i = startIdExercise; i <= countExercise; i++)
                {
                    exerciseDTO.Add(BLLMock.GetExerciseDTOMock(i));
                }

                List<Exercise> exercise = new List<Exercise>();
               
                for (int i = startIdExercise; i <= countExercise; i++)
                {
                    exercise.Add(BLLMock.GetExerciseMock(i));
                }
                yield return new object[]
                {
                    group,
                    exerciseDTO,
                    exercise
                };

                startIdExercise = 6;
                countExercise = 12;
                group = BLLMock.GetGroupMock(5);
                exerciseDTO = new List<ExerciseDTO>();

                for (int i = startIdExercise; i <= countExercise; ++i)
                {
                    exerciseDTO.Add(BLLMock.GetExerciseDTOMock(i));
                }

                exercise = new List<Exercise>();

                
                for (int i = startIdExercise; i <= countExercise; ++i)
                {
                    exercise.Add(BLLMock.GetExerciseMock(i));
                }

                yield return new object[]
                {
                    group,
                    exerciseDTO,
                    exercise
                };
            }
        }
    }
}
