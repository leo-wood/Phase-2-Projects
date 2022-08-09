import React, { ChangeEvent, useState } from 'react';
import axios from "axios";
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Tooltip from '@mui/material/Tooltip';
import IconButton from '@mui/material/IconButton';
import SearchIcon from '@mui/icons-material/Search';
import RefreshIcon from '@mui/icons-material/Refresh';
import button from "@mui/material/Button";

import './App.css';
import { title } from 'process';
import { Icon } from '@mui/material';


function App() {

  const [movieName, setMovieName] = useState("");
  const [movieInfo, setMovieInfo] = useState<undefined | any>(undefined);

  const [movieList, setMovieList] = useState([
    {
      Title: "Default movie",
      Year: "1998"
    }
  ]);

  const MOVIE_BASE_URL = "http://www.omdbapi.com/?t=";
  const APIKEY = "7cca2981";

  return (
    <div>
        <h1>
            Search for information on any movie using the OMDB API
        </h1>

        <h3>
          Click add movie to add your searched movie to the watchlist!
        </h3>

        <div>
          <label>Movie name</label><br/>
          <input type="text" id="movie-name" name="movie-name" onChange={e => setMovieName(e.target.value)}/><br/>

          <div>
          <button onClick={search}>
          Search
          </button>
          </div>
        </div>

        <div>
          <TextField 
          id='search-bar'
          className='text'
          value={movieName}
          onChange={(prop: any) => {
            setMovieName(prop.target.value);
          }}
          label="Enter a Movie name"
          variant='standard'
          placeholder='Try "Candyman"'
          size='small'
          />

          <IconButton
            aria-label='search'
            onClick={() => {
              search()
            }}>
              <SearchIcon style={{ fill: "blue" }} />
            </IconButton>

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

          <div>
            <ul>
              {movieList.map((movie) => (
                <div key={movie.Title}>
                  <p>{movie.Title}, {movie.Year}</p>
                  <hr/>
                </div>
              ))}
            </ul>
            <button onClick={handleAddNewMovie}>Add movie</button>
            <button onClick={handleRemoveMovie}>Pop the latest</button>
            </div>    
    </div>

    
  );

  function search(){
    axios.get(MOVIE_BASE_URL + movieName + "&apikey=" + APIKEY).then((res) => {

      setMovieInfo(res.data);

    })
  }
  
  function handleAddNewMovie(){ 
    console.log(movieList.indexOf(movieInfo.Title))
    const updateMovies = [
        ...movieList, {
          Title: movieInfo.Title,
          Year: movieInfo.Year
        }
      ];
      setMovieList(updateMovies)

  }

  function handleRemoveMovie(){
    movieList.pop();
    const updateMovies = [
      ...movieList, {
        Title: movieInfo.Title,
        Year: movieInfo.Year
      }
    ];
    setMovieList(movieList);
  }

}

export default App;
