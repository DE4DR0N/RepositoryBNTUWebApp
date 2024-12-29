import { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

const PublicationDetail = () => {
    const { publicationId } = useParams();
    const [publication, setPublication] = useState(null);

    useEffect(() => {
        axios.get(`/api/publications/${publicationId}`)
            .then(response => setPublication(response.data))
            .catch(error => console.error(error));
    }, [publicationId]);

    if (!publication) {
        return <div className="container mx-auto p-4 bg-primary min-h-screen">Loading...</div>;
    }

    return (
        <div className="mx-auto p-4 justify-items-center bg-primary min-h-screen">
            <div className="bg-white p-8 rounded shadow-md">
                <h2 className="text-4xl font-bold mb-4">{publication.title}</h2>
                <p className="text-xl mb-4">{publication.description}</p>
                <p className="text-2xl text-gray-600">ISBN: {publication.isbn}</p>
                <p className="text-2xl text-gray-600">Publish Date: {new Date(publication.publishDate).toLocaleDateString()}</p>
                <p className="text-2xl text-gray-600">Author: {publication.author.firstName} {publication.author.lastName}</p>
                <p className="text-2xl text-gray-600">Category: {publication.category.name}</p>
            </div>
        </div>
    );
};

export default PublicationDetail;
