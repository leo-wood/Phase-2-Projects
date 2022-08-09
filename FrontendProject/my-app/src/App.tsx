import React, { useState } from 'react';
import axios from "axios";
import logo from './logo.svg';
import './App.css';

function App() {

  const [movieName, setMovieName] = useState("");
  const [movieInfo, setMovieInfo] = useState<undefined | any>(undefined);

  const MOVIE_BASE_URL = "http://www.omdbapi.com/?t=";
  const APIKEY = "apikey=7cca2981";
  
  return (
    <div>
        <h1>
            Search for your favourite movie to check off your list
        </h1>

        <div>
          <label>Movie name</label><br/>
          <input type="text" id="movie-name" name="movie-name" onChange={e => setMovieName(e.target.value)}/><br/>

          <button onClick={search}>
          Search
          </button>
        </div>
        <p>You have searched for {movieName}</p>

          {movieInfo === undefined ? (
            <p>The movie was not found</p>
          ) : (
            <p>
              <div>{movieInfo.Title}</div>
              <div>{movieInfo.Year}</div>
              <div>{movieInfo.Director}</div>
              <div>{movieInfo.Runtime}</div>
              <div>{movieInfo.Genre}</div>
              
              
            </p>
          )}
        
    </div>
  );

  function search(){
    axios.get(MOVIE_BASE_URL + movieName + "&" + APIKEY).then((res) => {

      setMovieInfo(res.data);

    })
  }

}

export default App;
