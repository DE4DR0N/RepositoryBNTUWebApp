import { useEffect, useState } from 'react';
import axios from 'axios';
import {Link, useParams} from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

const Favourites = () => {
    const { userId } = useParams();
    const [publications, setPublications] = useState([]);
    const { isAuthenticated } = useAuth();

    useEffect(() => {
        axios.get(`/api/users/${userId}/publications`)
            .then(response => setPublications(response.data))
            .catch(error => console.error(error));
    }, [userId]);

    return (
        <div className="mx-auto p-4 bg-primary min-h-screen">
            <h2 className="text-2xl font-bold mb-4">Favourites</h2>
            {isAuthenticated && (
                <>
                    <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                        {publications.map(publication => (
                            <li key={publication.id} className="bg-white p-4 rounded shadow">
                                <h3 className="text-xl font-semibold mb-2">
                                    <Link to={`/publications/edit/${publication.id}`}>{publication.title}</Link>
                                </h3>
                                <p className="text-gray-700">{publication.description}</p>
                                <p className="text-sm text-gray-600 mt-2">ISBN: {publication.isbn}</p>
                                <p className="text-sm text-gray-600">Author: {publication.author.firstName} {publication.author.lastName}</p>
                                <p className="text-sm text-gray-600">Category: {publication.category.name}</p>
                            </li>
                        ))}
                    </ul>
                </>
            )}
        </div>
    );
};

export default Favourites;
