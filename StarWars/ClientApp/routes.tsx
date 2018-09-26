import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';

import { Counter } from './components/Counter';
import { FetchEpisodesData } from './components/Episodes';
import { FetchFactionsData } from './components/Factions';
//import { Characters } from './components/Characters';
//import { Starships } from './components/Starships';
//<Route path='/starwars/factions' component={factions} />
    //<Route path='/starwars/characters' component={characters} />
    //<Route path='/starwars/starships' component={starships} />


export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/counter' component={ Counter } />
    <Route path='/fetchdata' component={FetchData} />
    <Route path='/starwars/episodes' component={FetchEpisodesData} />
    <Route path='/starwars/factions' component={FetchFactionsData} />
    
</Layout>;
