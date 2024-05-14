import { useState } from 'react';
import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Clan from './Clan.jsx'

function App() {
    const [username] = useState('Guest');
    const [clanList] = useState([
        { name: "Clan A", points: 100 },
        { name: "Clan B", points: 150 },
        { name: "Clan C", points: 200 },
        { name: "Clan D", points: 200 }
    ]);
    const [selectedClan, setSelectedClan] = useState(null);

    const handleJoinClan = (clan) => {
        // Perform joining clan logic here
        setSelectedClan(clan);
    };

    const customFunction1 = () => {
        // Define your custom function 1 here
    };

    const customFunction2 = () => {
        // Define your custom function 2 here
    };

    return (
        <div>
            <h1>Welcome, {username}!</h1>
            {selectedClan ? (
                <div>
                    <BrowserRouter>
                        <Routes>
                            <Route index element={<Clan />} />
                        </Routes>
                    </BrowserRouter>
                </div>
            ) : (
                <div>
                    <h2>You are not in a clan</h2>
                    <p>Please select a clan to join:</p>
                        <ul>
                            {clanList.map((clan, index) => (
                                <li key={index} style={{ display: 'flex', alignItems: 'center' }}>
                                    <span>
                                        {clan.name} - Points: {clan.points}
                                    </span>

                                    <button style={{ marginLeft: '10px', width: '100px' }} onClick={() => handleJoinClan(clan)}>Join</button>
                                    {/* Adjust the '100px' value as needed */}
                                </li>
                            ))}
                        </ul>
                </div>
            )}

            {/* Space for custom functions */}
            
        </div>
    );
}

export default App;