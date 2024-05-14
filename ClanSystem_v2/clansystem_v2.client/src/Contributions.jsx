import { useState } from 'react';
import './App.css';

function App() {
    const [username] = useState('Guest');
    const [clanName] = useState('Awesome Clan');
    const [currentContributions] = useState([
        { user: 'User1', contribution: 50 },
        { user: 'User2', contribution: 30 },
        { user: 'User3', contribution: 20 }
    ]);

    const handleCloseWeb = () => {
        window.close();
    };

    return (
        <div>
            <h1>Current Contributions for {clanName}</h1>
            <ul>
                {currentContributions.map((contribution, index) => (
                    <li key={index}>
                        User Name: {contribution.user} - Current Points: {contribution.contribution}
                    </li>
                ))}
            </ul>
            <button onClick={handleCloseWeb}>Close Web</button>
            <p>Logged in as: {username}</p>
        </div>
    );
}

export default App;