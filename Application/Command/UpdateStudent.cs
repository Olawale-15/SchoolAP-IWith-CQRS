using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Command
{
    public class UpdateStudent
    {
        public record UpdateStudentCommand(string Name, string Phone, string Email):IRequest<UpdateStudentResponse>;
        public record UpdateStudentResponse(Guid Id, string Name,  string Phone, string Email);

        public class Handler : IRequestHandler<UpdateStudentCommand, UpdateStudentResponse>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
            {
                _studentRepository = studentRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<UpdateStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
            {
                var getStudent = await _studentRepository.GetStudentAsync(x => x.Email == request.Email);
                if (getStudent == null)
                {
                    throw new Exception("student not found");
                }

                
                getStudent.Name = request.Name ?? getStudent.Name;
                getStudent.Phone = request.Phone ?? getStudent.Phone;
                getStudent.Email = request.Email ?? getStudent.Email;
                _studentRepository.UpdateStudent(getStudent);
                await _unitOfWork.SaveAsync();

                return getStudent.Adapt<UpdateStudentResponse>();
            }
        }
    }
}
