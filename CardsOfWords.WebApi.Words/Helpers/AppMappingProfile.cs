using AutoMapper;
using CardsOfWords.WebApi.Words.Data.Entities;
using CardsOfWords.WebApi.Words.Models.AppVersion;
using CardsOfWords.WebApi.Words.Models.Language;
using CardsOfWords.WebApi.Words.Models.Word;
using CardsOfWords.WebApi.Words.Models.WordGroup;

namespace CardsOfWords.WebApi.Words.Helpers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<AppVersionRequestModel, AppVersion>();

            CreateMap<LanguageRequestModel, Language>();
            CreateMap<WordGroupRequestModel, WordGroup>();
            CreateMap<WordRequestModel, Word>();

            CreateMap<Language,LanguageResponseModel>();
            CreateMap<WordGroup, WordGroupResponseModel>();
            CreateMap<Word, WordResponseModel>();
        }
    }
}
