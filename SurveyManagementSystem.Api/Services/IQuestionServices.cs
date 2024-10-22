using SurveyManagementSystem.Api.Contracts.Question;

namespace SurveyManagementSystem.Api.Services;

public interface IQuestionServices
{
    Task<Result<IEnumerable<QuestionResponse>>> GetAllAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<QuestionResponse>> GetAsync(int pollId, int questionId, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<QuestionResponse>>> GetAvailableAsync(int pollId, string UserId, CancellationToken cancellationToken = default);
    Task<Result<QuestionResponse>> AddAsync(int pollId, QuestionRequest request, CancellationToken cancellationToken = default);
    Task<Result<QuestionResponse>> UpdateAsync(int pollId, int questionId, QuestionRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(int pollId, int questionId, CancellationToken cancellationToken = default);
}
