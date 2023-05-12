using System;
using Application.Dto.Applicant;
using Application.Dto.ApplicantDocument;
using Application.Dto.ApplicantExam;
using Application.Dto.ApplicantStatu;
using Application.Dto.DocumentGroup;
using Application.Dto.Exam;
using Application.Dto.JobPosting;
using Application.Dto.JobPostingDetail;
using Application.Dto.JobType;
using Application.Dto.JobTypeDocument;
using Application.Dto.Position;
using Application.Dto.PositionExam;
using Application.Dto.PositionSpecificDocument;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //JobPosting
            CreateMap<JobPostingInputDto, JobPosting>().ReverseMap();
            CreateMap<JobPostingOutputDto, JobPosting>().ReverseMap();
            CreateMap<JobPostingInputDto, JobPostingOutputDto>().ReverseMap();

            //JobType
            CreateMap<JobTypeOutputDto, JobType>().ReverseMap();
            CreateMap<JobTypeInputDto, JobType>().ReverseMap();
            CreateMap<JobTypeInputDto, JobTypeOutputDto>().ReverseMap();

            //JobPostingDetail
            CreateMap<JobPostingDetailInputDto, JobPostingDetail>().ReverseMap();
            CreateMap<JobPostingDetailOutputDto, JobPostingDetail>().ReverseMap();
            CreateMap<JobPostingDetailInputDto, JobPostingDetailOutputDto>().ReverseMap();

            //JobTypeDocument
            CreateMap<JobTypeDocumentInputDto, JobTypeDocument>().ReverseMap();
            CreateMap<JobTypeDocumentOutputDto, JobTypeDocument>().ReverseMap();
            CreateMap<JobTypeDocumentInputDto, JobTypeDocumentOutputDto>().ReverseMap();

            //Exam
            CreateMap<ExamInputDto, Exam>().ReverseMap();
            CreateMap<ExamOutputDto, Exam>().ReverseMap();
            CreateMap<ExamInputDto, ExamOutputDto>().ReverseMap();

            //Position
            CreateMap<PositionInputDto, Position>().ReverseMap();
            CreateMap<PositionOutputDto, Position>().ReverseMap();

            //PositionExam
            CreateMap<PositionExamInputDto, PositionExam>().ReverseMap();
            CreateMap<PositionExamOutputDto, PositionExam>().ReverseMap();
            CreateMap<PositionExamInputDto, PositionExamOutputDto>().ReverseMap();

            //PositionSpecificDocument  
            CreateMap<PositionSpecificDocumentInputDto, PositionSpecificDocument>().ReverseMap();
            CreateMap<PositionSpecificDocumentOutputDto, PositionSpecificDocument>().ReverseMap();
            CreateMap<PositionSpecificDocumentInputDto, PositionSpecificDocumentOutputDto>().ReverseMap();

            //ApplicantStatus
            CreateMap<ApplicantStatuInputDto, ApplicantStatu>().ReverseMap();
            CreateMap<ApplicantStatuOutputDto, ApplicantStatu>().ReverseMap();
            CreateMap<ApplicantStatuInputDto, ApplicantStatuOutputDto>().ReverseMap();

            //ApplicantDocument
            CreateMap<ApplicantDocumentInputDto, ApplicantDocument>().ReverseMap();
            CreateMap<ApplicantDocumentOutputDto, ApplicantDocument>().ReverseMap();
            CreateMap<ApplicantDocumentInputDto, ApplicantDocumentOutputDto>().ReverseMap();

            //Applicant
            CreateMap<ApplicantInputDto, Applicant>().ReverseMap();
            CreateMap<ApplicantOutputDto, Applicant>().ReverseMap();
            CreateMap<ApplicantInputDto, ApplicantOutputDto>().ReverseMap();

            //ApplicantExam
            CreateMap<ApplicantExamInputDto, ApplicantExam>().ReverseMap();
            CreateMap<ApplicantExamOutputDto, ApplicantExam>().ReverseMap();
            CreateMap<ApplicantExamInputDto, ApplicantExamOutputDto>().ReverseMap();
         
            //DocumentGroup
            CreateMap<DocumentGroupInputDto, DocumentGroup>().ReverseMap();
            CreateMap<DocumentGroupOutputDto, DocumentGroup>().ReverseMap();
            CreateMap<DocumentGroupInputDto, DocumentGroupOutputDto>().ReverseMap();
        }
    }
}
