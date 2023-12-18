import React from 'react';
import logo from './logo.svg';
import './App.css';
import CountriesList from './components/countries';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <CountriesList />
      </header>
    </div>
  );
}

export default App;
