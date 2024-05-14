import { useState } from 'react';
import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Contributions from './Contributions.jsx'
function App() {
    const [username] = useState('Guest');
    const [clanName, setClanName] = useState('Awesome Clan');
    const [clanPoints, setClanPoints] = useState(500);
    const [addPoints, setAddPoints] = useState('');
    const [subtractPoints, setSubtractPoints] = useState('');
    const [setPoints, setSetPoints] = useState(0);
    const [showCont, setshowCont] = useState(false);
    const [currentContributions, setCurrentContributions] = useState([
        { user: 'User1', contribution: 50 },
        { user: 'User2', contribution: 30 },
        { user: 'User3', contribution: 20 }
    ]);

    const handleLeaveClan = () => {
        setClanName('');
        setClanPoints(0);
        setCurrentContributions([]);
    };

    const handleAddPoints = () => {
        setClanPoints(clanPoints + parseInt(addPoints));
    };

    const handleSubtractPoints = () => {
        setClanPoints(clanPoints - parseInt(subtractPoints));
    };

    const handleSetPoints = () => {
        setClanPoints(parseInt(setPoints));
    };

    const handleShowContributions = () => {
        setshowCont(true)
    };

    if (showCont) {
        return (
            <div>
                <BrowserRouter>
                    <Routes>
                        <Route index element={<Contributions />} />
                    </Routes>
                </BrowserRouter>
            </div>
        );
    }
    else {
        return (
            <div>
                {clanName ? (
                    <div>
                        <h1>You are a part of {clanName}</h1>
                        <button onClick={handleLeaveClan}>Leave Clan</button>
                        <p>Clan Current Points: {clanPoints}</p>
                        <div>
                            <h2>Manage Clan Points</h2>
                            <input
                                type="number"
                                placeholder="Add Points"
                                value={addPoints}
                                onChange={(e) => setAddPoints(e.target.value)}
                            />

                            <input
                                type="number"
                                placeholder="Subtract Points"
                                value={subtractPoints}
                                onChange={(e) => setSubtractPoints(e.target.value)}
                            />

                            <input
                                type="number"
                                placeholder="Set Points"
                                value={setPoints}
                                onChange={(e) => setSetPoints(e.target.value)}
                            />

                        </div>
                        <div>
                            <button onClick={handleAddPoints}>Add Points</button>
                            <button onClick={handleSubtractPoints}>Subtract Points</button>
                            <button onClick={handleSetPoints}>Set Points</button>

                        </div>
                        <button onClick={handleShowContributions}>Show Current Contributions</button>
                    </div>
                ) : (
                    <div>
                        <h2>You are not in a clan</h2>
                        {/* Render clan list or invite button */}
                    </div>
                )}
                <p>Logged in as: {username}</p>
            </div>
        );
    }
}

export default App;