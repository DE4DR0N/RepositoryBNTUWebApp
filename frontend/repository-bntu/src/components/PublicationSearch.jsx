import { useState } from 'react';
import axios from 'axios';
import PublicationList from './PublicationList';

const PublicationSearch = () => {
    const [searchTerm, setSearchTerm] = useState('');
    const [searchResults, setSearchResults] = useState([]);

    const handleSearch = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.get(`/api/publications/search?query=${searchTerm}`);
            setSearchResults(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="mx-auto p-4 bg-primary min-h-screen">
            <h2 className="text-2xl font-bold mb-4">Search Publications</h2>
            <form onSubmit={handleSearch} className="mb-4">
                <input
                    type="text"
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    className="p-2 border border-gray-300 rounded-md shadow-sm w-full"
                    placeholder="Search for publications..."
                />
                <button type="submit" className="mt-2 px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600">
                    Search
                </button>
            </form>
            {searchResults.length > 0 && (
                <PublicationList publications={searchResults} />
            )}
        </div>
    );
};

export default PublicationSearch;
