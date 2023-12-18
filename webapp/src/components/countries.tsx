import React, {useState, useEffect} from 'react';
import {CountryClient} from '../generated/CountryServiceClientPb';
import {CountryInformation, GetCountriesRequest} from '../generated/country_pb';

const CountriesList: React.FC = () => {
  const [countries, setCountries] = useState<CountryInformation[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const getCountries = async () => {
      try {
        setLoading(true);

        const client = new CountryClient('http://localhost:8080');

        const request = new GetCountriesRequest();
        const response = await client.getCountries(request, {});

        setCountries(response.getCountriesList());
        setLoading(false);
      } catch (error: any) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    getCountries();
  }, []);

  if (countries.length === 0) {
    return <div>No Data</div>;
  }
  return (
    <ul>
      {countries.map(country => (
        <li key={country.getCountryid()}>{country.getCountryname()}</li>
      ))}
    </ul>
  );
};

export default CountriesList;
