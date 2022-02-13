<template>
    <b-modal id="cliente-edit-modal" size="lg" :title="!!model.id ? 'Editar - Cliente' : 'Novo - Cliente'">
        <b-form>
            <b-form-group label="Nome:">
                <b-form-input v-model="model.nome"></b-form-input>
            </b-form-group>
            <b-form-group label="E-mail:">
                <b-form-input v-model="model.email"></b-form-input>
            </b-form-group>
            <b-form-group label="Data de Nascimento">
                <b-form-datepicker
                    placeholder="Seleciona uma data"
                    v-model="model.dataNascimento"
                    :date-format-options="{ year: 'numeric', month: 'numeric', day: 'numeric' }"
                    locale="pt-BR"
                ></b-form-datepicker>
            </b-form-group>
            <hr>
            <b-row>
                <b-col><h4>Telefones</h4></b-col>
                <b-col class="text-right align-self-center">
                    <b-button variant="primary" size="sm" v-on:click="addTelefone()">
                        <b-icon-plus></b-icon-plus>
                    </b-button>
                </b-col>
            </b-row>
            <b-row v-for="telefone in model.telefones" :key="telefone.id">
                <b-col>
                    <b-form-group label="Número">
                        <b-form-input v-model="telefone.numero"></b-form-input>
                    </b-form-group>
                </b-col>
                <b-col cols="4">
                    <b-form-group label="Tipo">
                        <b-form-select v-model="telefone.tipo"  :options="telefoneTipos"></b-form-select>
                    </b-form-group>
                </b-col>
                <b-col cols="2" class="text-right align-self-end mb-3">
                    <b-button v-on:click="removeTelefone(telefone)" variant="danger">
                        <b-icon-trash></b-icon-trash>
                    </b-button>
                </b-col>
            </b-row>
        </b-form>
        <template #modal-footer>
            <div class="w-100 text-right">
                <b-button variant="primary" class="mr-3" @click="save()">
                Salvar
                </b-button>
                <b-button variant="secondary" @click="closeModal()">
                    Fechar
                </b-button>
            </div>
      </template>
    </b-modal>
</template>

<script>
export default {
    name: "ClienteEditar",
    props: {
        model: Object,
    },
    data() {
        return {
            telefoneTipos: [
                { text: "Pessoal", value: 0 },
                { text: "Comercial", value: 1 },
                { text: "Residencial", value: 2 },
                { text: "Outros", value: 3 },
            ]
        }
    },
    methods: {
        addTelefone() {
            this.model.telefones.push({ id: 0 });
        },
        removeTelefone(telefone) {
            this.model.telefones.splice(
                this.model.telefones.indexOf(telefone), 1
            );
        },
        save() {
            this.$emit("save");
        },
        closeModal() {
            this.$emit("close-modal")
        }
        
    }
}
</script>

<style scoped>
</style>