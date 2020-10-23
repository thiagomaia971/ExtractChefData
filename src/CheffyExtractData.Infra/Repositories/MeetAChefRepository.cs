using System;
using Microsoft.CSharp;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CheffyExtractData.Domain.DTOs;
using CheffyExtractData.Domain.Interfaces.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CheffyExtractData.Infra.Repositories
{
    public class MeetAChefRepository : IMeetAChefRepository
    {
        public string BaseUrl => "https://meetachef.com";
        public string GraphQlUrl => "api/graphql";

        private string Query =>
            "{\"operationName\":\"Directory\",\"variables\":{\"params\":{\"page\":3,\"type\":\"profiles\",\"selectedFacets\":null,\"location\":{\"country\":null,\"state\":\"{state}\",\"city\":null,\"neighborhood\":null,\"postalCode\":\"\",\"range\":null},\"search\":null,\"selectedLanguageId\":null,\"selectedProviderTypes\":null}},\"query\":\"query Directory($params: directoryParams!) {\n  site {\n    _id\n    directory(params: $params) {\n      count\n      _id\n      ...Listings\n      ...FacetGroups\n      ...SiteKeywords\n      ...Breadcrumbs\n      ...LocationsDropdowns\n      ...MetaTags\n      ...Languages\n      ...HeaderCTA\n      ...InvertedCTA\n      ...KathyCTA\n      nearestLocation {\n        name\n        slug\n        __typename\n      }\n      __typename\n    }\n    __typename\n  }\n}\n\nfragment Listings on Directory {\n  listings {\n    avatar {\n      large_url\n      name\n      __typename\n    }\n    city {\n      name\n      __typename\n    }\n    country {\n      name\n      __typename\n    }\n    description\n    featured\n    lastSeenInWords\n    name\n    ownerName\n    path\n    payRate {\n      currency\n      type\n      unit\n      value\n      valueType\n      __typename\n    }\n    responseTimeInWords\n    site {\n      id\n      name\n      pk\n      __typename\n    }\n    state {\n      abbreviation\n      name\n      slug\n      __typename\n    }\n    years_experience\n    user {\n      id\n      last_online\n      __typename\n    }\n    __typename\n  }\n  __typename\n}\n\nfragment FacetGroups on Directory {\n  facetGroups {\n    slug\n    name\n    facets {\n      keyword\n      slug\n      slugs {\n        label\n        slug\n        __typename\n      }\n      name\n      path\n      type\n      count\n      __typename\n    }\n    __typename\n  }\n  __typename\n}\n\nfragment SiteKeywords on Directory {\n  siteKeywords {\n    href\n    keyword\n    type\n    __typename\n  }\n  __typename\n}\n\nfragment Breadcrumbs on Directory {\n  breadcrumbs {\n    name\n    path\n    __typename\n  }\n  __typename\n}\n\nfragment LocationsDropdowns on Directory {\n  locationDropdowns {\n    list {\n      isSelected\n      name\n      path\n      slug\n      __typename\n    }\n    name\n    __typename\n  }\n  __typename\n}\n\nfragment MetaTags on Directory {\n  metaTags {\n    property\n    name\n    content\n    __typename\n  }\n  __typename\n}\n\nfragment Languages on Directory {\n  languages {\n    id\n    label\n    isSelected\n    __typename\n  }\n  __typename\n}\n\nfragment HeaderCTA on Directory {\n  headerCta {\n    name\n    title\n    button {\n      link\n      text\n      __typename\n    }\n    text\n    __typename\n  }\n  __typename\n}\n\nfragment InvertedCTA on Directory {\n  invertedCta {\n    name\n    title\n    image\n    button {\n      link\n      text\n      __typename\n    }\n    text\n    __typename\n  }\n  __typename\n}\n\nfragment KathyCTA on Directory {\n  kathyCta {\n    name\n    title\n    image\n    button {\n      link\n      text\n      __typename\n    }\n    text\n    __typename\n  }\n  __typename\n}\n";
        
        public async Task<MeetAChefResult> ExtractData(int page, string state)
        {
            var request = new MeetAChefRequest
            {
                OperationName = "Directory",
                Variables = new MeetAChefVariablesRequest
                {
                    Params = new MeetAChefParamsRequest
                    {
                        Page = page,
                        Type = "profiles",
                        Location = new MeetAChefLocationRequest
                        {
                            State = state,
                            PostalCode = ""
                        }
                    }
                }
            };
            var result = await Post<MeetAChefResult>(JsonConvert.SerializeObject(request, new JsonSerializerSettings{ContractResolver = new CamelCasePropertyNamesContractResolver()}));
            var chefs = result.Data.Site.Directory.Listings;

            return result;
        }

        private async Task<T> Post<T>(string content)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                var result = await httpClient.PostAsync(GraphQlUrl, new StringContent(content, Encoding.UTF8, "application/json"));
                var readAsStringAsync = await result.Content.ReadAsStringAsync();
                if (!result.IsSuccessStatusCode)
                    throw new Exception(readAsStringAsync);
                return JsonConvert.DeserializeObject<T>(readAsStringAsync);
            }
        }
    }
}