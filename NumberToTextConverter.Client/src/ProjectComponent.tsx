import React, { useState } from 'react';

interface ResultResponse {
    status: number;
    summary: string;
}

const ConverterComponent: React.FC = () => {
    const [userInput, setUserInput] = useState<string>('');
    const [result, setResult] = useState<ResultResponse | null>(null);
    const [loading, setLoading] = useState<boolean>(false);

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUserInput(event.target.value);
    };

    const handleSubmit = async () => {
        setLoading(true);
        try {
            const response = await fetch(`/numbertotext/GetText/${userInput}`);
            const data: ResultResponse = await response.json();
            setResult(data);
        } catch (error) {
            console.error('Error fetching forecast:', error);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <div style={{ display: 'flex', marginBottom: '10px' }}> {/* Container with flex display */}
                <input
                    type="text"
                    placeholder="Enter number"
                    value={userInput}
                    onChange={handleInputChange}                    
                />
                <button onClick={handleSubmit} disabled={loading} style={{ marginLeft: '10px', backgroundColor: 'beige' }} >
                    {loading ? 'Loading...' : 'Get Result'}
                </button>
            </div>
            {result && (
                <div style={{ display: 'flex', marginBottom: '10px' }}>
                    <label>Result:  </label>
                    <label>  {result.summary}  </label>
                </div>
            )}
        </div>
    );
};

export default ConverterComponent;