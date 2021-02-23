<template>
    <div id="dialog-delete">
        <div class="modal"></div>
        <div class="dialog">
            <div class="dialog__header">
                <div class="title">Thông báo</div>
                <div class="icon icon-x" @click="close"></div>
            </div>
            <div class="dialog__content">{{message}}</div>
            <div class="dialog__footer">
                <div class="footer__item float--left"></div>
                <div class="footer__item float--right" v-if="mode === 'NOTIFICATION' || mode === null">
                    <button class="m-button" @click="close">Đồng ý</button>
                </div>
                <div class="footer__item float--right" v-if="mode === 'DELETE'">
                    <button class="m-button" @click="deleteFee">Xóa</button>
                </div>
                <div class="footer__item float--right" v-if="mode === 'DELETE'" >
                    <button class="m-second-button" @click="close">Không</button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import axios from 'axios'

export default {
    props: {
        message: String,
        listFeeId: Array,
        mode: String
    },
    methods: {
        close() {
            this.$emit('close');
        },
        async deleteFee() {
            for (let i in this.listFeeId) {
                await axios.delete('http://localhost:60931/api/v1/Fees/' + this.listFeeId[i])
                    .then(res => {
                        console.log(res.data);
                        this.$emit('reloadData');
                    })
                    .catch(res => {
                        alert(res);
                    })
            }
            this.$emit('close');
        }
    },
}
</script>
<style scoped>
.modal {
    position: fixed;
    width: 100vw;
    height: 100vh;
    top: 0;
    left: 0;
    background-color: #cccccc;
    opacity: 0.6;
    z-index: 3;
}

.dialog {
    position: fixed;
    z-index: 3;
    width: calc(400px - 24px - 24px);
    height: 200px;
    top: calc((100vh - 200px) / 2);
    left: calc((100vw - 400px) / 2);
    background-color: #fff;
    border-radius: 4px;
    padding-left: 24px;
    padding-right: 24px;
    overflow: hidden;
}

    .dialog .dialog__header {
        display: flex;
        align-items: center;
        width: 100%;
        height: 70px;
        overflow: hidden;
    }

        .dialog .dialog__header .title {
            font-family: 'OpenSans-Bold';
            font-size: 20px;
        }

        .dialog .dialog__header .icon {
            position: absolute;
            top: 12px;
            right: 12px;
            width: 16px;
            height: 16px;
            border-radius: 50%;
            cursor: pointer;
        }

    .dialog .dialog__content {
        display: flex;
        width: 100%;
        height: calc(100% - 70px - 70px);
    }

    .dialog .dialog__footer {
        width: 100%;
        height: 70px;
    }

        .dialog .dialog__footer .footer__item {
            width: auto;
            height: 100%;
            display: flex;
            align-items: center;
        }

        .dialog .dialog__footer .footer__item.float--right {
            margin-left: 8px;
        }
</style>