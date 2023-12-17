import { credentials } from '@grpc/grpc-js';
import { CountryClient } from '../../generated/country_grpc_pb';
import { GetCountriesRequest, GetCountriesResponse } from '../../generated/country_pb';

export async function GET() {
  const countryService = new CountryClient('localhost:9080', credentials.createInsecure());

  const request = new GetCountriesRequest();

  try {
    const response = await countryService.getCountries(request);
    const countries = response.getCountriesList();
    // Use the countries list in your response
    return Response.json({ countries });
  } catch (error) {
    console.error(error);
    // Handle error and return appropriate response
    return Response.json({ error: error.message });
  }
}