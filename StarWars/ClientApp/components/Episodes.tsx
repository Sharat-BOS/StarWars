import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchEpisodesState {
    episodes: Episodes[];
    loading: boolean;
}

export class FetchEpisodesData extends React.Component<RouteComponentProps<{}>, FetchEpisodesState> {
    constructor() {
        super();
        this.state = { episodes: [], loading: true };

        fetch('api/starwars/webapi/Episodes')
            .then(response => response.json() as Promise<Episodes[]>)
            .then(data => {
                this.setState({ episodes: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchEpisodesData.renderEpisodesCards(this.state.episodes);

        return <div>
            <h1>Starwars Episodes</h1>
            <p>This component demonstrates fetching episodes data from the server.</p>
            {contents}
        </div>;
    }

    private static renderEpisodesCards(episodes: Episodes[]) {
        return <div>
                   {episodes.map(episode =>
                       <div className="card" key={episode.id.toString()}>
                           <h5 className="card-header">{episode.episodeName}</h5>
                            <div className="card-body">
                                   <h5 className="card-title">{episode.episodeName}</h5>
                                   <p className="card-text">{episode.summary}</p>
                                <a href="#" className="btn btn-primary">Cast</a>
                            </div>
                    </div>
                        )
                   }
                </div>
        
    }
}

interface Episodes {
    id: string,
    episodeName: string; 
    summary: string;
}




//<table className='table'>
        //    <thead>
        //        <tr>
        //            <th>Date</th>
        //            <th>Temp. (C)</th>
        //            <th>Temp. (F)</th>
        //            <th>Summary</th>
        //        </tr>
        //    </thead>
        //    <tbody>
        //        {forecasts.map(forecast =>
        //            <tr key={forecast.dateFormatted}>
        //                <td>{forecast.dateFormatted}</td>
        //                <td>{forecast.temperatureC}</td>
        //                <td>{forecast.temperatureF}</td>
        //                <td>{forecast.summary}</td>
        //            </tr>
        //        )}
        //    </tbody>
        //</table>;