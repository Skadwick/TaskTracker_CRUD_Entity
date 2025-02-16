import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [rcomments, setRComments] = useState([]);

    useEffect(() => {
        populateRComments();
    }, []);

    const contents = rcomments === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>date</th>
                    <th>subreddit</th>
                    <th>body</th>
                    <th>link</th>
                </tr>
            </thead>
            <tbody>
                {rcomments.map(rcomments =>
                    <tr key={rcomments.id}>
                        <td>{rcomments.date}</td>
                        <td>{rcomments.subreddit}</td>
                        <td className="bdRow">{rcomments.body}</td>
                        <td><a target="_blank" rel="noopener noreferrer" href={rcomments.permalink}>link</a></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">R Comments</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
    
    async function populateRComments() {
        try {
            const response = await fetch('https://localhost:7019/api/RedditComments',{ method: 'GET' });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const text = await response.text(); // Read as plain text
            console.log("Raw response:", text); // Log response to check if it's HTML or JSON

            const data = JSON.parse(text); // Convert to JSON
            console.log("Parsed JSON:", data); // Debug output

            setRComments(data);
        } catch (error) {
            console.error("Error fetching comments:", error);
        }
    }


}

export default App;