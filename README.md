# ExtractChefData

## How to use

1. Run ```CheffyExtractData.ApiApplication``` project
1. Open your browser with the route: ```http:\\localhost:5000```
1. Expand ```ExtractData``` request
    - ```State:``` State you want to extract
    - ```Page:``` number you want to extract. (If null: will return all pages)
1. For last, click in ```Try it out```
    - Will return a objct with this structure:
```json
{
    "Result": [
        {
            "Avatar": {
                "large_url": string,
                "Name": string
            },
            "City": {
                "Name": string
            },
            "Country": {
                "Name": string
            },
            "Description": string,
            "Featured": boolean,
            "LastSeenInWords": string,
            "Name": string,
            "OwnerName": string,
            "Path": string,
            "PayRate": string,
            "ResponseTimeInWords": string,
            "State": {
                "Abbreviation": string,
                "Name": string,
                "Slug": string
            },
            "YearsExperience": int,
            "User": {
                "Id": string,
                "last_online": date
            }
        }
    ],
    "Exception": {...},
    "IsSuccess": boolean
}
```

## Under the hood

MeetAChef have an exposed GraphQL API with this route: ```https://meetachef.com/api/graphql```
So, I just get the body that the web site send to this API and replicate on my API.