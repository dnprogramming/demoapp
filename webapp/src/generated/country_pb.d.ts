import * as jspb from 'google-protobuf';

export class AddCountryRequest extends jspb.Message {
  getCountryname(): string;
  setCountryname(value: string): AddCountryRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): AddCountryRequest.AsObject;
  static toObject(
    includeInstance: boolean,
    msg: AddCountryRequest
  ): AddCountryRequest.AsObject;
  static serializeBinaryToWriter(
    message: AddCountryRequest,
    writer: jspb.BinaryWriter
  ): void;
  static deserializeBinary(bytes: Uint8Array): AddCountryRequest;
  static deserializeBinaryFromReader(
    message: AddCountryRequest,
    reader: jspb.BinaryReader
  ): AddCountryRequest;
}

export namespace AddCountryRequest {
  export type AsObject = {
    countryname: string;
  };
}

export class AddCountryResponse extends jspb.Message {
  getSuccess(): boolean;
  setSuccess(value: boolean): AddCountryResponse;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): AddCountryResponse.AsObject;
  static toObject(
    includeInstance: boolean,
    msg: AddCountryResponse
  ): AddCountryResponse.AsObject;
  static serializeBinaryToWriter(
    message: AddCountryResponse,
    writer: jspb.BinaryWriter
  ): void;
  static deserializeBinary(bytes: Uint8Array): AddCountryResponse;
  static deserializeBinaryFromReader(
    message: AddCountryResponse,
    reader: jspb.BinaryReader
  ): AddCountryResponse;
}

export namespace AddCountryResponse {
  export type AsObject = {
    success: boolean;
  };
}

export class GetCountriesRequest extends jspb.Message {
  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): GetCountriesRequest.AsObject;
  static toObject(
    includeInstance: boolean,
    msg: GetCountriesRequest
  ): GetCountriesRequest.AsObject;
  static serializeBinaryToWriter(
    message: GetCountriesRequest,
    writer: jspb.BinaryWriter
  ): void;
  static deserializeBinary(bytes: Uint8Array): GetCountriesRequest;
  static deserializeBinaryFromReader(
    message: GetCountriesRequest,
    reader: jspb.BinaryReader
  ): GetCountriesRequest;
}

export namespace GetCountriesRequest {
  export type AsObject = {};
}

export class GetCountryRequest extends jspb.Message {
  getCountryid(): string;
  setCountryid(value: string): GetCountryRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): GetCountryRequest.AsObject;
  static toObject(
    includeInstance: boolean,
    msg: GetCountryRequest
  ): GetCountryRequest.AsObject;
  static serializeBinaryToWriter(
    message: GetCountryRequest,
    writer: jspb.BinaryWriter
  ): void;
  static deserializeBinary(bytes: Uint8Array): GetCountryRequest;
  static deserializeBinaryFromReader(
    message: GetCountryRequest,
    reader: jspb.BinaryReader
  ): GetCountryRequest;
}

export namespace GetCountryRequest {
  export type AsObject = {
    countryid: string;
  };
}

export class GetCountriesResponse extends jspb.Message {
  getCountriesList(): Array<CountryInformation>;
  setCountriesList(value: Array<CountryInformation>): GetCountriesResponse;
  clearCountriesList(): GetCountriesResponse;
  addCountries(value?: CountryInformation, index?: number): CountryInformation;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): GetCountriesResponse.AsObject;
  static toObject(
    includeInstance: boolean,
    msg: GetCountriesResponse
  ): GetCountriesResponse.AsObject;
  static serializeBinaryToWriter(
    message: GetCountriesResponse,
    writer: jspb.BinaryWriter
  ): void;
  static deserializeBinary(bytes: Uint8Array): GetCountriesResponse;
  static deserializeBinaryFromReader(
    message: GetCountriesResponse,
    reader: jspb.BinaryReader
  ): GetCountriesResponse;
}

export namespace GetCountriesResponse {
  export type AsObject = {
    countriesList: Array<CountryInformation.AsObject>;
  };
}

export class GetCountryResponse extends jspb.Message {
  getCountry(): CountryInformation | undefined;
  setCountry(value?: CountryInformation): GetCountryResponse;
  hasCountry(): boolean;
  clearCountry(): GetCountryResponse;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): GetCountryResponse.AsObject;
  static toObject(
    includeInstance: boolean,
    msg: GetCountryResponse
  ): GetCountryResponse.AsObject;
  static serializeBinaryToWriter(
    message: GetCountryResponse,
    writer: jspb.BinaryWriter
  ): void;
  static deserializeBinary(bytes: Uint8Array): GetCountryResponse;
  static deserializeBinaryFromReader(
    message: GetCountryResponse,
    reader: jspb.BinaryReader
  ): GetCountryResponse;
}

export namespace GetCountryResponse {
  export type AsObject = {
    country?: CountryInformation.AsObject;
  };
}

export class CountryInformation extends jspb.Message {
  getCountryid(): string;
  setCountryid(value: string): CountryInformation;

  getCountryname(): string;
  setCountryname(value: string): CountryInformation;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): CountryInformation.AsObject;
  static toObject(
    includeInstance: boolean,
    msg: CountryInformation
  ): CountryInformation.AsObject;
  static serializeBinaryToWriter(
    message: CountryInformation,
    writer: jspb.BinaryWriter
  ): void;
  static deserializeBinary(bytes: Uint8Array): CountryInformation;
  static deserializeBinaryFromReader(
    message: CountryInformation,
    reader: jspb.BinaryReader
  ): CountryInformation;
}

export namespace CountryInformation {
  export type AsObject = {
    countryid: string;
    countryname: string;
  };
}
