import { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

const CategoryList = () => {
    const [categories, setCategories] = useState([]);
    const { isAuthenticated, userRole } = useAuth();

    useEffect(() => {
        axios.get('/api/categories')
            .then(response => setCategories(response.data))
            .catch(error => console.error(error));
    }, []);

    return (
        <div className="mx-auto p-4 bg-primary min-h-screen">
            <h2 className="text-2xl font-bold mb-4">Categories</h2>
            {isAuthenticated && userRole === 'Admin' && (
                <Link to="/categories/new" className="mb-4 inline-block bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600">
                    Add Category
                </Link>
            )}
            <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                {categories.map(category => (
                    <li key={category.id} className="bg-white p-4 rounded shadow hover:bg-gray-100 transition">
                        <Link to={`/categories/${category.id}/publications`} className="block">
                            <h3 className="text-xl font-semibold mb-2">{category.name}</h3>
                        </Link>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CategoryList;
