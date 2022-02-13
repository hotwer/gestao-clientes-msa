import http from '../axios.bootstrap';

const controller = 'Clientes';

export default {

    // api methods
    async all() {
        try {
            const response = await http.get(controller);

            return response.data;
        } catch (e) {
            console.error(e);
        }

        return [];
    },
    async get(id) {
        try {
            const response = await http.get(`${controller}/${id}`);

            return response.data;
        } catch (e) {
            console.error(e);
        }

        return null;
    },
    async update(model) {
        try {
            const isNew = !model.id;

            if (isNew) {
                model.id = 0;
            }

            return await http.post(
                `${controller}/${model.id}`,
                model
            );
        } catch (e) {
            console.error(e);
        }

        return null;
    },
    async delete(id) {
        try {
            const response = await http.delete(
                `${controller}/${id}`
            );

            return response.data;
        } catch (e) {
            console.error(e);
        }

        return null;
    },
}