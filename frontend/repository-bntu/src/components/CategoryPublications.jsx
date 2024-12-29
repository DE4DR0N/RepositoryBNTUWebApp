import { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

const CategoryPublications = () => {
    const { categoryId } = useParams();
    const [publications, setPublications] = useState([]);
    const [category, setCategory] = useState(null);

    useEffect(() => {
        axios.get(`/api/Categories/${categoryId}/publications`)
            .then(response => setPublications(response.data))
            .catch(error => console.error(error));

        axios.get(`/api/Categories/${categoryId}`)
            .then(response => setCategory(response.data))
            .catch(error => console.error(error));
    }, [categoryId]);

    return (
        <div className="mx-auto p-4 bg-primary min-h-screen">
            {category && (
                <h2 className="text-2xl font-bold mb-4">{category.name} Publications</h2>
            )}
            <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                {publications.map(publication => (
                    <li key={publication.id} className="bg-white p-4 rounded shadow">
                        <h3 className="text-xl font-semibold mb-2">{publication.title}</h3>
                        <p className="text-gray-700">{publication.description}</p>
                        <p className="text-sm text-gray-600 mt-2">ISBN: {publication.isbn}</p>
                        <p className="text-sm text-gray-600">Author: {publication.author.firstName} {publication.author.lastName}</p>
                        <p className="text-sm text-gray-600">Category: {publication.category.name}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CategoryPublications;
