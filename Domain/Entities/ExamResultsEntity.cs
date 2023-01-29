using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class ExamResultsEntity
    {
        public ExamYear ExamYear { get; }
        public Haruaki Haruaki{ get; }
        public SolvedDate SolvedDate { get; }
    
        public Score Score { get; }
        public ExamResultsEntity(
            int examYear,
            int haruaki,
            DateTime solvedDate,
            int score
            )
        {
            ExamYear = new ExamYear( examYear );
            Haruaki = new Haruaki( haruaki );
            SolvedDate = new SolvedDate( solvedDate );
            Score = new Score( score );
        }
    }
}
