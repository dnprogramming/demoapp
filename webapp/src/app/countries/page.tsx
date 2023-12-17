import React from 'react';
import axios from 'axios';
import {headers} from 'next/headers';

export default function Countries() {
  const header = headers();
  const host = header.get('host') as string;
  const url = host.startsWith('localhost')
    ? 'http://' + host
    : 'https://' + host;
  const data = axios.get(url + '/api/countries');
  console.log(data);
  return <div>Hello World!</div>;
}
