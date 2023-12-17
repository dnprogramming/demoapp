// GENERATED CODE -- DO NOT EDIT!

'use strict';
const grpc = require('@grpc/grpc-js');
const country_pb = require('./country_pb.js');

function serialize_countries_AddCountryRequest(arg) {
  if (!(arg instanceof country_pb.AddCountryRequest)) {
    throw new Error('Expected argument of type countries.AddCountryRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_countries_AddCountryRequest(buffer_arg) {
  return country_pb.AddCountryRequest.deserializeBinary(
    new Uint8Array(buffer_arg)
  );
}

function serialize_countries_AddCountryResponse(arg) {
  if (!(arg instanceof country_pb.AddCountryResponse)) {
    throw new Error('Expected argument of type countries.AddCountryResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_countries_AddCountryResponse(buffer_arg) {
  return country_pb.AddCountryResponse.deserializeBinary(
    new Uint8Array(buffer_arg)
  );
}

function serialize_countries_GetCountriesRequest(arg) {
  if (!(arg instanceof country_pb.GetCountriesRequest)) {
    throw new Error('Expected argument of type countries.GetCountriesRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_countries_GetCountriesRequest(buffer_arg) {
  return country_pb.GetCountriesRequest.deserializeBinary(
    new Uint8Array(buffer_arg)
  );
}

function serialize_countries_GetCountriesResponse(arg) {
  if (!(arg instanceof country_pb.GetCountriesResponse)) {
    throw new Error('Expected argument of type countries.GetCountriesResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_countries_GetCountriesResponse(buffer_arg) {
  return country_pb.GetCountriesResponse.deserializeBinary(
    new Uint8Array(buffer_arg)
  );
}

function serialize_countries_GetCountryRequest(arg) {
  if (!(arg instanceof country_pb.GetCountryRequest)) {
    throw new Error('Expected argument of type countries.GetCountryRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_countries_GetCountryRequest(buffer_arg) {
  return country_pb.GetCountryRequest.deserializeBinary(
    new Uint8Array(buffer_arg)
  );
}

function serialize_countries_GetCountryResponse(arg) {
  if (!(arg instanceof country_pb.GetCountryResponse)) {
    throw new Error('Expected argument of type countries.GetCountryResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_countries_GetCountryResponse(buffer_arg) {
  return country_pb.GetCountryResponse.deserializeBinary(
    new Uint8Array(buffer_arg)
  );
}

const CountryService = (exports.CountryService = {
  addCountry: {
    path: '/countries.Country/AddCountry',
    requestStream: false,
    responseStream: false,
    requestType: country_pb.AddCountryRequest,
    responseType: country_pb.AddCountryResponse,
    requestSerialize: serialize_countries_AddCountryRequest,
    requestDeserialize: deserialize_countries_AddCountryRequest,
    responseSerialize: serialize_countries_AddCountryResponse,
    responseDeserialize: deserialize_countries_AddCountryResponse,
  },
  getCountries: {
    path: '/countries.Country/GetCountries',
    requestStream: false,
    responseStream: false,
    requestType: country_pb.GetCountriesRequest,
    responseType: country_pb.GetCountriesResponse,
    requestSerialize: serialize_countries_GetCountriesRequest,
    requestDeserialize: deserialize_countries_GetCountriesRequest,
    responseSerialize: serialize_countries_GetCountriesResponse,
    responseDeserialize: deserialize_countries_GetCountriesResponse,
  },
  getCountry: {
    path: '/countries.Country/GetCountry',
    requestStream: false,
    responseStream: false,
    requestType: country_pb.GetCountryRequest,
    responseType: country_pb.GetCountryResponse,
    requestSerialize: serialize_countries_GetCountryRequest,
    requestDeserialize: deserialize_countries_GetCountryRequest,
    responseSerialize: serialize_countries_GetCountryResponse,
    responseDeserialize: deserialize_countries_GetCountryResponse,
  },
});

exports.CountryClient = grpc.makeGenericClientConstructor(CountryService);
