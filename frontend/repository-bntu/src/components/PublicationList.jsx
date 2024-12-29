import { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

// eslint-disable-next-line react/prop-types
const PublicationList = ({ publications, currentPage, setCurrentPage }) => {
    const [allPublications, setAllPublications] = useState([]);
    const [totalPages, setTotalPages] = useState(0);
    const { isAuthenticated, userRole } = useAuth();
    const pageSize = 10;

    useEffect(() => {
        if (!publications) {
            axios.get(`/api/publications?page=${currentPage}&pageSize=${pageSize}`)
                .then(response => {
                    setAllPublications(response.data.publicationViewModels);
                    setTotalPages(response.data.totalPages);
                })
                .catch(error => console.error(error));
        }
    }, [publications, currentPage]);

    const displayPublications = publications || allPublications;

    const handleDelete = async (id) => {
        try {
            await axios.delete(`/api/publications/${id}`);
            setAllPublications(allPublications.filter(publication => publication.id !== id));
        } catch (error) {
            console.error("Error deleting publication:", error);
        }
    };

    const handlePageChange = (page) => {
        if (page < 1 || page > totalPages) return;
        setCurrentPage(page);
    };

    return (
        <div className="mx-auto p-4 bg-primary min-h-screen">
            <h2 className="text-2xl font-bold mb-4">Publications</h2>
            {isAuthenticated && userRole === 'Admin' && (
                <Link to="/publications/new" className="mb-4 inline-block bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600">
                    Add Publication
                </Link>
            )}
            <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                {displayPublications && displayPublications.map(publication => (
                    <li key={publication.id} className="bg-white p-4 rounded shadow">
                        <h3 className="text-xl font-semibold mb-2">
                            <Link to={`/publications/${publication.id}`}>{publication.title}</Link>
                        </h3>
                        <p className="text-gray-700">{publication.description}</p>
                        <p className="text-sm text-gray-600 mt-2">ISBN: {publication.isbn}</p>
                        <p className="text-sm text-gray-600">Author: {publication.author.firstName} {publication.author.lastName}</p>
                        <p className="text-sm text-gray-600">Category: {publication.category.name}</p>
                        {isAuthenticated && userRole === 'Admin' && (
                            <>
                                <Link to={`/publications/edit/${publication.id}`} className="text-blue-500 hover:underline ml-4 bg-gray-100 px-3 py-1 rounded hover:bg-blue-500 hover:text-white transition duration-200 ease-in-out">
                                    Edit
                                </Link>
                                <button onClick={() => handleDelete(publication.id)} className="text-red-500 hover:underline ml-4 bg-gray-100 px-3 py-1 rounded hover:bg-red-500 hover:text-white transition duration-200 ease-in-out">
                                    Delete
                                </button>
                            </>
                        )}
                    </li>
                ))}
            </ul>
            <div className="flex justify-center mt-4">
                <button onClick={() => handlePageChange(currentPage - 1)} disabled={currentPage === 1} className="px-4 py-2 bg-gray-300 rounded hover:bg-gray-400 mx-1">
                    Previous
                </button>
                <span className="px-4 py-2">{currentPage} / {totalPages}</span>
                <button onClick={() => handlePageChange(currentPage + 1)} disabled={currentPage === totalPages} className="px-4 py-2 bg-gray-300 rounded hover:bg-gray-400 mx-1">
                    Next
                </button>
            </div>
        </div>
    );
};

export default PublicationList;
