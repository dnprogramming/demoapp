import React, {useState, useEffect} from 'react';
import {CountryClient} from '../generated/CountryServiceClientPb';
import {
  AddCountryRequest,
  CountryInformation,
  GetCountriesRequest,
} from '../generated/country_pb';

const CountriesList: React.FC = () => {
  const [countries, setCountries] = useState<CountryInformation[]>([]);
  const [newCountry, setNewCountry] = useState('');
  const client = new CountryClient('http://localhost:8080');

  useEffect(() => {
    getCountries();
  }, []);

  const getCountries = async () => {
    const request = new GetCountriesRequest();
    const response = await client.getCountries(request, {});
    setCountries(response.getCountriesList());
  };

  useEffect(() => {
    getCountries();
  }, []);

  const handleSubmit = async event => {
    event.preventDefault();

    try {
      const request = new AddCountryRequest();

      request.setCountryname(newCountry);
      await client.addCountry(request);
      getCountries();
    } catch (error) {
      console.error(error);
      alert('Error submitting form!');
    }
  };

  return (
    <>
      <form onSubmit={handleSubmit}>
        <label>
          Country:
          <input
            type="text"
            value={newCountry}
            onChange={e => setNewCountry(e.target.value)}
          />
        </label>
        <button type="submit">Submit</button>
      </form>
      {countries.length > 0 && (
        <ul>
          {countries.map(country => (
            <li key={country.getCountryid()}>{country.getCountryname()}</li>
          ))}
        </ul>
      )}
    </>
  );
};

export default CountriesList;
