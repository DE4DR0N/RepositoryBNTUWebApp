import { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate, useParams } from 'react-router-dom';

const PublicationForm = () => {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [isbn, setIsbn] = useState('');
    const [publishDate, setPublishDate] = useState('');
    const [categoryId, setCategoryId] = useState('');
    const [authorId, setAuthorId] = useState('');
    const [categories, setCategories] = useState([]);
    const [authors, setAuthors] = useState([]);
    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        axios.get('/api/categories').then(response => setCategories(response.data));
        axios.get('/api/authors').then(response => setAuthors(response.data));

        if (id) {
            axios.get(`/api/publications/${id}`).then(response => {
                const publication = response.data;
                setTitle(publication.title);
                setDescription(publication.description);
                setIsbn(publication.isbn);
                setPublishDate(publication.publishDate);
                setCategoryId(publication.category.id);
                setAuthorId(publication.author.id);
            });
        }
    }, [id]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        const publicationData = { title, description, isbn, publishDate, categoryId, authorId };

        try {
            if (id) {
                await axios.put(`/api/publications/${id}`, publicationData);
            } else {
                await axios.post('/api/publications', publicationData);
            }
            navigate('/');
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="mx-auto p-4 bg-primary min-h-screen flex justify-center items-center">
            <div className="bg-white p-8 rounded shadow-md w-full max-w-md">
                <h2 className="text-2xl font-bold mb-6 text-center">{id ? 'Edit Publication' : 'Add Publication'}</h2>
                <form onSubmit={handleSubmit} className="space-y-4">
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Title</label>
                        <input
                            type="text"
                            value={title}
                            onChange={(e) => setTitle(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Description</label>
                        <textarea
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">ISBN</label>
                        <input
                            type="text"
                            value={isbn}
                            onChange={(e) => setIsbn(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Publish Date</label>
                        <input
                            type="date"
                            value={publishDate}
                            onChange={(e) => setPublishDate(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Category</label>
                        <select
                            value={categoryId}
                            onChange={(e) => setCategoryId(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        >
                            <option value="">Select a category</option>
                            {categories.map(category => (
                                <option key={category.id} value={category.id}>
                                    {category.name}
                                </option>
                            ))}
                        </select>
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Author</label>
                        <select
                            value={authorId}
                            onChange={(e) => setAuthorId(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        >
                            <option value="">Select an author</option>
                            {authors.map(author => (
                                <option key={author.id} value={author.id}>
                                    {author.firstName} {author.lastName}
                                </option>
                            ))}
                        </select>
                    </div>
                    <button type="submit" className="w-full py-2 bg-blue-500 text-white rounded hover:bg-blue-600">
                        {id ? 'Update Publication' : 'Add Publication'}
                    </button>
                </form>
            </div>
        </div>
    );
};

export default PublicationForm;
