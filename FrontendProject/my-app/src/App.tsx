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
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Divider from '@mui/material/Divider';
import InboxIcon from '@mui/icons-material/Inbox';
import DraftsIcon from '@mui/icons-material/Drafts';
import { title } from 'process';
import { Icon } from '@mui/material';


import './App.css';


function App() {

  const [movieName, setMovieName] = useState("");
  const [movieInfo, setMovieInfo] = useState<undefined | any>(undefined);

  const [movieList, setMovieList] = useState([
    {
      Title: "No Country For Old Men",
      Year: "2007"
    }
  ]);

  const MOVIE_BASE_URL = "http://www.omdbapi.com/?t=";
  const APIKEY = "7cca2981";

  const searchButton = document.getElementById('search-bar');

  searchButton?.addEventListener('keypress', function handleClick(event) {
    if(event.key === "Enter") {
      document.getElementById("search-button")?.click();
    }
  
});


  return (
    
    <div id="main-body">
        <h1>
            Search for information on any movie using the OMDB API
        </h1>
        
        <h3>
          Click the search icon to find the movie from the API
        </h3>
        


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
          margin="dense"
          />

          <IconButton
            id="search-button"
            aria-label='search'
            onClick={() => {
              search()
            }}>
              <SearchIcon style={{ fill: "blue" }} />
            </IconButton>

        </div>


        

          {movieInfo === undefined ? (
            <p>The movie was not found</p>
          ) : (
            <div id="search-results">
            <p>
              Title: {movieInfo.Title}<br/>
              
              Release: {movieInfo.Year}<br/>
              
              Director: {movieInfo.Director}<br/>
              
              Runtime: {movieInfo.Runtime}<br/>
              
              Genre: {movieInfo.Genre}
              
            </p>
            </div>
          )}

          <Grid container spacing={2}>
            <Grid item xs={4}>
          <div>
            <ul>
              {movieList.map((movie) => (
                <div key={movie.Title}>
                  <p>{movie.Title}, {movie.Year}</p>
                  <hr/>
                </div>
              ))}
            </ul>
            <Button variant="contained" onClick={handleAddNewMovie}>Add to Watchlist</Button>
            
            <Button variant="outlined" onClick={handleRemoveMovie}>Pop the latest movie</Button>
            </div>
            </Grid>
            <Grid item xs={1}>
            
            </Grid>
            <Grid item xs={4}>
              <p>
                Until further updates, a default movie needs to start in the list, hence No Country For Old Men is there
                <br/>
                <br/>
                Pop button does work! <br/>
                It just requires you to change the text in the input search field for it to display the new list.. unsure why
              </p>

            </Grid>

            </Grid>
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
