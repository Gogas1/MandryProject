using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs;
using Mandry.Models.DTOs.ApiDTOs.Categories;
using Mandry.Models.Requests.Housing;
using Mandry.Models.DTOs.ApiDTOs.Features;
using Mandry.Models.Requests.Parameters;
using Mandry.Models.Requests.Feature;
using Mandry.Models.Requests.Reviews;
using Mandry.Models.DTOs.ApiDTOs.Reviews;
using Mandry.Models.DTOs;
using Azure;

namespace Mandry.Extensions
{
    public static class MappingExtensions
    {
        #region Housing
        public static HousingDTO ToHousingDTO(this Housing housing)
        {           
            HousingDTO housingDTO = new HousingDTO();
            housingDTO.Id = housing.Id.ToString();
            housingDTO.PricePerNight = housing.PricePerNight;
            housingDTO.CleaningFee = housing.CleaningFee;
            housingDTO.Name = housing.Name;
            housingDTO.OneLineDescription = housing.OneLineDescription;
            housingDTO.ShortDescription = housing.ShortDescription;
            housingDTO.Description = housing.Description;
            housingDTO.LocationPlace = housing.LocationPlace;
            housingDTO.LocationCountry = housing.LocationCountry;
            housingDTO.MaxGuests = housing.MaxGuests;
            housingDTO.Bathrooms = housing.Bathrooms;
            housingDTO.CategoryProperty = housing.CategoryProperty ?? string.Empty;
            housingDTO.AverageRating = housing.AverageRating;
            housingDTO.Category = new CategoryDTO()
            {
                Id = housing.Category.Id.ToString(),
                NameKey = housing.Category.NameKey,
                CategoryPropertyDescriptionKey = housing.Category.CategoryPropertyDescriptionKey,
                IsCategoryPropertyRequired = housing.Category.IsCategoryPropertyRequired,
                CategoryTranslations = housing.Category.Translation.Select(t => new TranslationDTO() { Key = t.TranslationKey, LanguageCode = t.Language, Text = t.TranslationString }).ToList(),               
            };
            if(housing.FeatureHousings != null)
            {
                housingDTO.Features = housing.FeatureHousings.Select(fh =>
                {
                    var featureDTO = new FeatureDataDTO();
                    featureDTO.Id = fh.Feature.Id.ToString();
                    featureDTO.NameCode = fh.Feature.NameKey;
                    featureDTO.DescriptionCode = fh.Feature.DescriptionKey;
                    featureDTO.TypeCode = fh.Feature.TypeKey;
                    featureDTO.IsAllowPinning = fh.Feature.IsAllowPinning;
                    featureDTO.IsRecommended = fh.Feature.IsRecomended;
                    featureDTO.IsAllowCustomName = fh.Feature.IsAllowCustomName;
                    featureDTO.IsAllowCustomDescription = fh.Feature.IsAllowCustomDescription;
                    featureDTO.IsHouseRule = fh.Feature.IsHouseRule;
                    featureDTO.IsSafetyFeature = fh.Feature.IsSafetyFeature;
                    featureDTO.FeatureIcon = new ImageDTO() { Id = fh.Feature.FeatureImage.Id.ToString(), Src = fh.Feature.FeatureImage.Src };
                    featureDTO.Translations = fh.Feature.Translation.Select(t => new TranslationDTO() { Key = t.TranslationKey, LanguageCode = t.Language, Text = t.TranslationString }).ToList();
                    featureDTO.Parameters = fh.ParametersValues.Select(pv =>
                    {
                        var parameterDto = new ParameterDTO();
                        parameterDto.Value = pv.Value;
                        parameterDto.ParameterKey = pv.Parameter.ParameterKey;

                        return parameterDto;
                    }).ToList();

                    return featureDTO;
                }).ToList();
            }
            housingDTO.Availabilities = housing.Availabilities.ToDays();
            housingDTO.Bedrooms = housing.Bedrooms.Select(b =>
            {
                BedroomDTO bedroom = new BedroomDTO();
                bedroom.Beds = b.Beds.Select(bed => new BedDTO() { Size = bed.NumberOfPeople }).ToList();

                return bedroom;
            }).ToList();
            housingDTO.Images = housing.Images.Select(i => new ImageDTO() { Id = i.Id.ToString(), Src = i.Src }).ToList();

            return housingDTO;
        }

        public static Housing ToHousing(this HousingDTO housingDTO)
        {
            Housing housing = new Housing();
            housing.Id = Guid.Parse(housingDTO.Id);
            housing.PricePerNight = housingDTO.PricePerNight;
            housing.Name = housingDTO.Name;
            housing.Description = housingDTO.Description;
            housing.ShortDescription = housingDTO.ShortDescription;
            housing.OneLineDescription = housingDTO.OneLineDescription;
            housing.CategoryProperty = housingDTO.CategoryProperty;
            housing.LocationPlace = housingDTO.LocationPlace;
            housing.LocationCountry = housingDTO.LocationCountry;
            housing.LocationCoords = housingDTO.LocationCoords;
            housing.MaxGuests = housingDTO.MaxGuests;
            housing.Bathrooms = housingDTO.Bathrooms;
            housing.Category = new Category() 
            { 
                Id = Guid.Parse(housingDTO.Category.Id), 
                NameKey = housingDTO.Category.NameKey,
                CategoryPropertyDescriptionKey = housingDTO.Category.CategoryPropertyDescriptionKey,
                IsCategoryPropertyRequired = housingDTO.Category.IsCategoryPropertyRequired
            };
            housing.Availabilities = housingDTO.Availabilities.ToAvailabilities();
            housing.FeatureHousings = housingDTO.Features.Select(feat =>
            {
                var newFeatureHousing = new FeatureHousing();
                newFeatureHousing.Feature = new Feature() { Id = Guid.Parse(feat.Id) };

                return newFeatureHousing;
            }).ToList();
            housing.Images = housingDTO.Images.Select(img =>
            {
                return new Image() { Id = Guid.Parse(img.Id) };
            }).ToList();
            housing.Bedrooms = housingDTO.Bedrooms.Select(b =>
            {
                var newBedroom = new Bedroom();
                newBedroom.Beds = b.Beds.Select(bed => new Bed() { NumberOfPeople = bed.Size }).ToList();

                return newBedroom;
            }).ToList();


            return housing;
        }

        public static Housing ToHousing(this AddHousingModel model)
        {
            Housing housing = new Housing();
            housing.ShortDescription = model.ShortDescription;
            housing.Description = model.Description;
            housing.Category = new Category() { Id = Guid.Parse(model.CategoryId) };
            housing.Name = model.Name;
            housing.LocationCountry = model.LocationCountry;
            housing.LocationPlace = model.LocationPlace;
            housing.Bathrooms = model.Bathrooms;
            housing.CategoryProperty = model.CategoryProperty;
            housing.OneLineDescription = model.OneLineDescription;
            housing.LocationCoords = model.LocationCoords;
            housing.Bedrooms = model.Bedrooms.Select(b =>
            {
                var newBedroom = new Bedroom();
                newBedroom.Beds = b.Beds.Select(bed => new Bed() { NumberOfPeople = bed.Size }).ToList();

                return newBedroom;
            }).ToList();
            housing.FeatureHousings = model.Features.Select(feat =>
            {
                var newFeatureHousing = new FeatureHousing();
                newFeatureHousing.Feature = new Feature() { Id = Guid.Parse(feat.Id) };
                newFeatureHousing.ParametersValues = feat.Parameters.Select(p =>
                {
                    var newHousingFeatureParameter = new ParameterFeatureHousing();
                    newHousingFeatureParameter.Parameter = new Parameter() { Id = Guid.Parse(p.Id) };
                    newHousingFeatureParameter.Value = p.Value;

                    return newHousingFeatureParameter;
                }).ToList();

                return newFeatureHousing;
            }).ToList();
            housing.Images = model.Images.Select(img =>
            {
                return new Image() { Id = Guid.Parse(img.Id) };
            }).ToList();
            housing.PricePerNight = model.PricePerNight;
            housing.CleaningFee = model.CleaningFee;
            housing.MaxGuests = model.MaxGuests;
            housing.Availabilities = model.Availabilities.ToAvailabilities();

            return housing;
        }

        #endregion Housing

        #region Availabilities
        public static List<DateTime> ToDays(this ICollection<Availability> availabilities)
        {
            List<DateTime> days = new List<DateTime>();
            foreach (var availability in availabilities)
            {
                for (DateTime date = availability.From.Date; date <= availability.To.Date; date = date.AddDays(1))
                {
                    days.Add(date);
                }
            }

            return days;
        }

        public static List<Availability> ToAvailabilities(this ICollection<DateTime> days)
        {
            var daysList = days.OrderBy(date => date).ToList();

            List<Availability> intervals = new List<Availability>();
            if (daysList.Count == 0) return intervals;

            DateTime intervalStart = daysList[0];
            DateTime intervalEnd = daysList[0];

            for (int i = 1; i < daysList.Count; i++)
            {
                if ((daysList[i] - intervalEnd).Days == 1)
                {
                    intervalEnd = daysList[i];
                }
                else
                {
                    intervals.Add(new Availability { From = intervalStart, To = intervalEnd });

                    intervalStart = daysList[i];
                    intervalEnd = daysList[i];
                }
            }

            intervals.Add(new Availability { From = intervalStart, To = intervalEnd });

            return intervals;
        }
        #endregion Availabilities

        #region Translations

        public static Translation ToTranslation(this TranslationDTO translationDTO)
        {
            Translation translation = new();
            translation.TranslationKey = translationDTO.Key;
            translation.Language = translationDTO.LanguageCode;
            translation.TranslationString = translationDTO.Text;

            return translation;
        }

        public static TranslationDTO ToDTO(this Translation translation)
        {
            TranslationDTO translationDTO = new();
            translationDTO.Text = translation.TranslationString;
            translationDTO.Key = translation.TranslationKey;
            translationDTO.LanguageCode = translation.Language;

            return translationDTO;
        }

        #endregion Translations

        #region Parameters

        public static Parameter ToParameter(this AddParameterModel model)
        {
            Parameter parameter = new Parameter();
            parameter.NameKey = model.NameKey;
            parameter.DefaultValue = model.DefaultValue;
            parameter.Translation = model.Translations.Select(t => t.ToTranslation()).ToList();
            parameter.ParameterKey = model.ParameterKey;

            return parameter;
        }

        public static ParameterDTO ToDTO(this Parameter parameter)
        {
            ParameterDTO parameterDTO = new ParameterDTO();
            parameterDTO.Id = parameter.Id.ToString();
            parameterDTO.NameKey = parameter.NameKey;
            parameterDTO.ParameterKey = parameter.ParameterKey;
            parameterDTO.DefaultValue = parameter.DefaultValue;
            parameterDTO.Translations = parameter.Translation.Select(t => t.ToDTO()).ToList();

            return parameterDTO;
        }

        #endregion Parameters

        #region Features

        public static Feature ToFeature(this AddFeatureModel model)
        {
            Feature newFeature = new Feature();
            newFeature.NameKey = model.NameCode;
            newFeature.DescriptionKey = model.DescriptionCode;
            newFeature.IsAllowCustomDescription = model.IsAllowCustomDescription;
            newFeature.IsAllowCustomName = model.IsAllowCustomName;
            newFeature.IsAllowPinning = model.IsAllowPinning;
            newFeature.IsHouseRule = model.IsHouseRule;
            newFeature.IsRecomended = model.IsHouseRule;
            newFeature.IsCounterFeature = model.IsCounterFeature;
            newFeature.IsSafetyFeature = model.IsSafetyFeature;
            newFeature.TypeKey = model.TypeCode;
            newFeature.FeatureImage = new Image()
            {
                Id = Guid.Parse(model.FeatureIcon.Id),
            };
            newFeature.Translation = model.Translations.Select(t => new Translation()
            {
                Language = t.LanguageCode,
                TranslationKey = t.Key,
                TranslationString = t.Text
            }).ToList();
            newFeature.Parameters = model.Parameters.Select(p => p.ToParameter()).ToList();

            return newFeature;
        }

        public static FeatureDataDTO ToDTO(this Feature feature)
        {
            FeatureDataDTO featureDataDTO = new FeatureDataDTO();
            featureDataDTO.Id = feature.Id.ToString();
            featureDataDTO.NameCode = feature.NameKey;
            featureDataDTO.DescriptionCode = feature.DescriptionKey;
            featureDataDTO.IsAllowCustomName = feature.IsAllowCustomName;
            featureDataDTO.IsAllowCustomDescription = feature.IsAllowCustomDescription;
            featureDataDTO.IsHouseRule = feature.IsHouseRule;
            featureDataDTO.IsRecommended = feature.IsRecomended;
            featureDataDTO.IsAllowPinning = feature.IsAllowPinning;
            featureDataDTO.TypeCode = feature.TypeKey;
            featureDataDTO.FeatureIcon = new ImageDTO()
            {
                Id = feature.FeatureImage.Id.ToString(),
                Src = feature.FeatureImage.Src,
            };
            featureDataDTO.Translations = feature.Translation.Select(t => t.ToDTO()).ToList();
            featureDataDTO.Parameters = feature.Parameters.Select(p => p.ToDTO()).ToList();

            return featureDataDTO;
        }

        #endregion Features

        #region Reviews

        public static Review ToReview(this AddReviewModel model)
        {
            Review review = new Review();
            review.Rating = model.Rating;
            review.Text = model.Text;

            return review;
        }

        public static ReviewDTO ToDTO(this Review review)
        {
            ReviewDTO reviewDTO = new ReviewDTO();
            reviewDTO.Creator = review.From.ToDTO(false);
            reviewDTO.Text = review.Text;
            reviewDTO.Rating = review.Rating;
            reviewDTO.CreatedAt = review.CreatedAt;

            return reviewDTO;
        }

        #endregion

        #region User

        public static UserDataDTO ToDTO(this User user, bool detailed = true, bool includeAbout = false)
        {
            UserDataDTO userData = new UserDataDTO();
            userData.Id = user.Id.ToString();
            userData.Name = user.Name;
            userData.Surname = user.Surname;
            if (user.ProfileImage != null)
            {
                userData.Avatar = new ImageDTO() { Src = user.ProfileImage.Src, Id = user.ProfileImage.Id.ToString() };
            }

            if(detailed)
            {
                userData.Phone = user.Phone ?? string.Empty;
                userData.Email = user.Email ?? string.Empty;
            }            

            if(includeAbout)
            {
                if(user.UserAbout != null)
                {
                    var userAbout = user.UserAbout;
                    userData.UserAbout = new Models.DTOs.User.UserAboutDTO()
                    {
                        Biography = userAbout.Biography,
                        Birthdate = userAbout.Birthday,
                        Education = userAbout.Education,
                        Fact = userAbout.Fact,
                        MainHobby = userAbout.Hobby,
                        Languages = userAbout.Languages,
                        Residence = userAbout.Location,
                        Pets = userAbout.Pets,
                        Skills = userAbout.Skills,
                        Song = userAbout.Song,
                        Profession = userAbout.Profession,
                        TimeThings = userAbout.TimeThings,
                        AboutMe = userAbout.AboutMe
                    };
                }
            }

            return userData;
        }

        #endregion User

        #region Image

        public static ImageDTO? ToDTO(this Image image)
        {
            if (image == null) return null;
            return new ImageDTO()
            {
                Id = image.Id.ToString(),
                Src = image.Src
            };
        }

        #endregion Image
    }
}
