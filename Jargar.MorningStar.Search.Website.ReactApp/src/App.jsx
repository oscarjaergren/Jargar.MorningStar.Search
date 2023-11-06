import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { persons: [], loading: true, searchQuery: '' };
    }

    componentDidMount() {
        this.populatePersons();
    }

    static renderPersonsTable(persons) {
        return (
            <table role="row" className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email</th>
                        <th>Gender</th>
                    </tr>
                </thead>
                <tbody>
                    {persons.map(person => (
                        <tr key={person.id} >
                            <td>{person.id}</td>
                            <td>{person.firstName}</td>
                            <td>{person.lastName}</td>
                            <td>{person.email}</td>
                            <td>{person.gender}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }

    handleSearch = async () => {
        const response = await fetch(`person/api/search?term=${this.state.searchQuery}`);
        const data = await response.json();
        this.setState({ persons: data });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderPersonsTable(this.state.persons);

        return (
            <div>
                <h1 id="tabelLabel" >Persons</h1>
                <p>This component demonstrates fetching data from the server via search functionality.</p>
                <div>
                    <input
                        type="text"
                        placeholder="Search by first name, last name, or email"
                        value={this.state.searchQuery}
                        onChange={(e) => this.setState({ searchQuery: e.target.value })}
                    />
                    <button onClick={this.handleSearch}>Search</button>
                </div>
                {contents}
            </div>
        );
    }

    async populatePersons() {
        const response = await fetch('person/api/get');
        const data = await response.json();
        this.setState({ persons: data, loading: false });
    }
}
