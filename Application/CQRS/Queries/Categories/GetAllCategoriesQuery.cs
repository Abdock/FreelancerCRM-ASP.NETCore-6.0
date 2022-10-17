using Application.Responses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Categories;

public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryResponse>>
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponse>> Handle(GetAllCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            return categories.Select(category => _mapper.Map<CategoryResponse>(category)).ToList();
        }
    }
}