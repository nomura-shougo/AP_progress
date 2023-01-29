using Domain.Entities;

namespace Domain.Repositories
{
    public interface IExamResultsRepository
    {
        IReadOnlyList<ExamResultsEntity> GetData();

        ExamResultsEntity? GetSingleData(ExamResultsEntity examResult);
        void Save(ExamResultsEntity examResults);
    }
}
