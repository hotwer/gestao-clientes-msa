<template>
    <div>
        <b-row>
            <b-col>
                <h1>Clientes: </h1>
            </b-col>
            <b-col class="text-right align-self-center">
                <b-button variant="primary" v-on:click="editarCliente()">
                    <b-icon-plus></b-icon-plus>
                </b-button>
            </b-col>
        </b-row>
        <b-table striped hover :fields="fields" :items="items">
            <template #cell(dataNascimento)="data">
                {{ formatDate(data.item.dataNascimento) }}
            </template> 
            <template #cell(telefones)="data">
                {{ data.item.telefones.map((i) => `${i.numero}`).join(', ') }}
            </template> 
            <template #cell(actions)="data">
                <b-button v-on:click="editarCliente(data.item.id)" size="sm" variant="primary" style="margin-right: 0.25em" >
                    <b-icon-pencil-square></b-icon-pencil-square>
                </b-button>
                <b-button v-on:click="excluirCliente(data.item.id)" variant="danger" size="sm">
                    <b-icon-trash></b-icon-trash>
                </b-button>
            </template>
        </b-table>
        <ClienteEditar :model="selectedCliente" @save="salvarCliente()" @close-modal="closeClienteModal()" />
    </div>
</template>

<script>
import ClienteEditar from './ClienteEditar.vue'
import ClienteService from '../services/cliente.service';  

const CLIENTE_EDITAR_MODAL_ID = 'cliente-edit-modal';

export default {
    name: "Clientes",
    components: {
        ClienteEditar
    },
    data() {
        return {
            fields: [
                {
                    key: "id",
                    label: "ID",
                    thStyle: "width: 5em"
                },
                {
                    key: "nome",
                },
                {
                    key: "dataNascimento",
                    label: "Data de Nascimento",
                    thStyle: "width: 12em"
                },
                { 
                    key: "telefones",
                    thStyle: "width: 30em" 
                },
                {
                    key: "actions",
                    label: "",
                    class: "text-center",
                    thStyle: "width: 10em"
                }
            ],
            items: [],
            selectedCliente: { telefones: [] },
        }
    },
    methods: {
        async loadClientes() {
            this.items = await ClienteService.all();
        },

        async editarCliente(id) {
            this.selectedCliente = !id ? 
                { telefones: [] } : await ClienteService.get(id);

            this.openClienteModal();
        },

        async salvarCliente() {
            const isNew = !this.selectedCliente.id;

            await ClienteService.update(this.selectedCliente);
            
            this.$bvToast.toast(
                isNew ? 
                    `Cliente cadastrado com sucesso!`
                    : `Cliente atualizado com sucesso!`, 
                { 
                    title: isNew ? "Cliente cadastrado" : "Cliente atualizado", 
                    variant: "success" 
                }
            );

            this.loadClientes();
        },

        async excluirCliente(id) {
            const self = this;

            this.$root.$emit("dialoger:ask", { 
                message: "Você tem certeza que deseja excluir esse registro?",
                callback: async (confirmation) => {
                    if (!confirmation) return; // skip 

                    const data = await ClienteService.delete(id);

                    self.$bvToast.toast(
                        data.mensagem, 
                        { 
                            title: data.status ? "Sucesso!" : "Oops!", 
                            variant: data.status ? "success" : "danger" 
                        }
                    );

                    self.loadClientes()
                }
            });

            
            
        },

        // screen modal methods
        openClienteModal() {
            this.$bvModal.show(CLIENTE_EDITAR_MODAL_ID);
        },
        closeClienteModal() {
            this.$bvModal.hide(CLIENTE_EDITAR_MODAL_ID);
        },

        // helpers
        formatDate(date) {
            return this.momentjs(date).format('DD/MM/YYYY')
        }
    },
    created() {
        this.loadClientes();
    }
}
</script>

<style scoped>
</style>