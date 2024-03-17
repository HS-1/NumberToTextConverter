import React from 'react';
import './App.css';
import ProjectComponent from './ProjectComponent';

const App: React.FC = () => {
    return (
        <div className="container">
            <h1>Number to text converter</h1>
            <h6>Number will round to 2 decimal</h6>
            <ProjectComponent />
        </div>
    );
};

export default App;