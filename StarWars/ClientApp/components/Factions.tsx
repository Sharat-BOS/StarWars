import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchFactionsState {
    factions: Faction[];
    loading: boolean;
}

export class FetchFactionsData extends React.Component<RouteComponentProps<{}>, FetchFactionsState> {
    constructor() {
        super();
        this.state = { factions: [], loading: true };

        fetch('api/starwars/webapi/Factions')
            .then(response => response.json() as Promise<Faction[]>)
            .then(data => {
                this.setState({ factions: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchFactionsData.renderFactionCards(this.state.factions);

        return <div>
            <h1>Starwars Factions</h1>
            <p>This component demonstrates fetching factions data from the server.</p>
            {contents}
        </div>;
    }

    private static renderFactionCards(factions: Faction[]) {
        return <div style={{ width: '25%' }}>
            {
                factions.map(faction =>
                    <div className="card" key={faction.id.toString()} >
                        <img className="card-img-top" src={faction.imageUrl} alt="Card image cap" style={{ marginLeft:'10px', width:'100px'}} />
                    <div className="card-body">
                        <h5 className="card-title pull-left">{faction.factionName}</h5>
                        <p className="card-text"></p>
                        <a href="#" className="btn btn-primary">Characters</a>
                    </div>
                </div>
            )
            }
        </div>

    }   
 }
//style = {{ width: '18rem' }}
interface CharacterType {
    id: number,
    characterTypeName: string   
}

interface CharacterGroup {
    id: number,
    characterGroupName: string
}

interface Starship {
    id: number,
    starshipName: string,
    imageUrl:string,
}

interface Episode {
    id: string,
    episodeName: string;
    summary: string;
}


interface Character {
    id: number,
    characterName: string,
    characterTypeID:number,
    characterType: CharacterType
    characterGroupID:number   
    starships: Starship,
    homePlanet:string,
    purpose:string,
    factionID:number,
    imageUrl:string 
}


interface Faction {
    id: string,
    factionName: string;
    characters: Character[],
    imageUrl: string
}
