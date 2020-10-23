namespace CheffyExtractData.Domain.DTOs
{
    public class MeetAChefRequest
    {
        public string OperationName { get; set; }
        public MeetAChefVariablesRequest Variables { get; set; }

        public string Query = @"query Directory($params: directoryParams!) {
site {
_id
directory(params: $params) {
count
_id
...Listings
...FacetGroups
...SiteKeywords
...Breadcrumbs
...LocationsDropdowns
...MetaTags
...Languages
...HeaderCTA
...InvertedCTA
...KathyCTA
nearestLocation {
name
slug
__typename
}
__typename
}
__typename
}
}

fragment Listings on Directory {
listings {
avatar {
large_url
name
__typename
}
city {
name
__typename
}
country {
name
__typename
}
description
featured
lastSeenInWords
name
ownerName
path
payRate {
currency
type
unit
value
valueType
__typename
}
responseTimeInWords
site {
id
name
pk
__typename
}
state {
abbreviation
name
slug
__typename
}
years_experience
user {
id
last_online
__typename
}
__typename
}
__typename
}

fragment FacetGroups on Directory {
facetGroups {
slug
name
facets {
keyword
slug
slugs {
label
slug
__typename
}
name
path
type
count
__typename
}
__typename
}
__typename
}

fragment SiteKeywords on Directory {
siteKeywords {
href
keyword
type
__typename
}
__typename
}

fragment Breadcrumbs on Directory {
breadcrumbs {
name
path
__typename
}
__typename
}

fragment LocationsDropdowns on Directory {
locationDropdowns {
list {
isSelected
name
path
slug
__typename
}
name
__typename
}
__typename
}

fragment MetaTags on Directory {
metaTags {
property
name
content
__typename
}
__typename
}

fragment Languages on Directory {
languages {
id
label
isSelected
__typename
}
__typename
}

fragment HeaderCTA on Directory {
headerCta {
name
title
button {
link
text
__typename
}
text
__typename
}
__typename
}

fragment InvertedCTA on Directory {
invertedCta {
name
title
image
button {
link
text
__typename
}
text
__typename
}
__typename
}

fragment KathyCTA on Directory {
kathyCta {
name
title
image
button {
link
text
__typename
}
text
__typename
}
__typename
}";
    }
}