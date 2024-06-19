# StarkExplorer

A tool to view and analyse transactions, blockchain metrics and other data, maybe via Infura or the Starkscan API.
Three parts:

* API library
* Console program, calls the API library and provides results on the command line
* GUI program, calls the API library and provides results graphically

## Infura API key
Stark data is fetched via the [Infura Starknet API](https://docs.infura.io/api/networks/starknet).
I have used a [free Infura account](https://www.infura.io/pricing) that gives
* 1 API key
* 100,000 Total Requests/Day
* 10 Requests/Second

Which is more than enough for my requirements.

An API key is required and should be stored as an environment variable called ``INFURA_APIKEY`` on the machine that runs StarknetExplorer. This is so that the key does not have to be stored in a software repository, Github in this case. The app will throw an exception if it cannot find ``INFURA_APIKEY``.


## Credits

| Library  | Function  | Link  |
| --- | ---   |  --- |
| Json.NET | .Net JSON framework | https://www.newtonsoft.com/json |
| NUnit | .Net Unit-testing framework | https://nunit.org/ |
| NLog | .Net Logging platform | https://nlog-project.org/  |
|   |   |   |
|   |   |   |

