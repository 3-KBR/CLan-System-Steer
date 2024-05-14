import { useState, useEffect } from 'react';
import './App.css';

function App() {
    const [user, setUser] = useState();

    useEffect(() => {
        fetchUser("Ali"); // Fetch user with username "Ali" initially
    }, []);

    const fetchUser = async (username) => {
        try {
            const response = await fetch(`https://localhost:7148/api/Relation/Get?username=${username}`);
            const userData = await response.json();
            setUser(userData);
        } catch (error) {
            console.error('Error fetching user:', error);
        }
    };

    return (
        <div>
            <h1>User Details</h1>
            {user && (
                <div>
                    <p>Username: {user.username}</p>
                    <p>Other Details:</p>
                    <pre>{JSON.stringify(user, null, 2)}</pre>
                </div>
            )}
        </div>
    );
}

export default App;
