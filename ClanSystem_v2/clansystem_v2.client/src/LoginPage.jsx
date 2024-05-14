import React, { useState, useEffect } from 'react';
//import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import JoinClan from './JoinClan.jsx'
import Clan from './Clan.jsx'

function App() {
    const [username, setUsername] = useState('');
    const [loggedIn, setLoggedIn] = useState(false);
    const [notUser, setNotUser] = useState(false);

    const handleLogin = async () => {
        try {
            setNotUser(true);
            const response = await fetch("https://localhost:7148/api/User/Get", {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ username })
            });

            if (response.ok) {
                // Username exists in the database
                setLoggedIn(true);
            } else {
                // Username does not exist in the database
                setNotUser(true);
            }
        } catch (error) {
            console.error('Error logging in:', error);
            // Handle error - show error message to the user or retry login
        }
    };

    const handleUsernameChange = (event) => {
        setUsername(event.target.value);
    };

    if (loggedIn) {
        return (
            <div>
                <BrowserRouter>
                    <Routes>
                        <Route index element={<Clan />} />
                    </Routes>
                </BrowserRouter>
            </div>
        );
    }
    else if (notUser) {
        return (
            <div>
                <BrowserRouter>
                    <Routes>
                        <Route index element={<JoinClan />} />
                    </Routes>
                </BrowserRouter>
            </div>
        );
    }
    else {
        return (
            <div>
                <h1>Login</h1>
                <div>
                    <input
                        type="text"
                        placeholder="Enter your username"
                        value={username}
                        onChange={handleUsernameChange}
                    />
                </div>
                <div>
                    <button onClick={handleLogin}>Login</button>
                </div>
            </div>


        );
    }
}

export default App;